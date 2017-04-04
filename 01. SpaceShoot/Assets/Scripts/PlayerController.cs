using UnityEngine;

using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private Transform t_airPlanePlayer;

    [SerializeField]
    private float m_airPlaneSpeed = (float) 8;

    [SerializeField]
    private Animator [] m_airPlaneAnimation;

    [SerializeField]
    private Rigidbody t_bullet;

    [SerializeField]
    private Transform t_firePosition;
    //private GameObject t_firePosition;

    private float m_airPlaneHorizontalAxis;

    [SerializeField]
    private Transform m_enemyRespawn;

    [SerializeField]
    private Transform t_enemy;

    [SerializeField]
    private float m_currentTime;

    [SerializeField]
    private float m_beforeTime;

    [SerializeField]
    private float m_cDTime;

    private Transform m_clone;


    //public Image playerHPUI;

    //public float maxHP = (float)100;
    //public float currentHP = (float)100;

    // Use this for initialization
    void Start () {
        //m_airPlaneAnimation = t_airPlanePlayer.gameObject.GetComponent<Animator>();
        m_airPlaneAnimation = t_airPlanePlayer.gameObject.GetComponentsInChildren<Animator>();

        // 初始時將時間同步，用於每隔 2 秒產生敵機
        m_beforeTime = m_currentTime;

    }
	
	// Update is called once per frame
	void Update () {

        // 如果 Air Plane 玩家被消滅的話，將 GM Empty Object 的程式碼 disable，就不會因為找不到 Air Plane 物件而導致錯誤。
        if (t_airPlanePlayer == null)
        {
            this.GetComponent<PlayerController>().enabled = false;
        }
        airPlanControlFunction();
        enemyRespawn();

        //playerHPUI.fillAmount = currentHP / maxHP;
    }


    // 用於敵機的生成
    void enemyRespawn()
    {
        // 記錄目前的時間
        m_currentTime = Time.time;

        Vector3 newEnemyRespawn = new Vector3(Random.Range((float)-5.5,(float)5.5), m_enemyRespawn.position.y, m_enemyRespawn.position.z);

        // 如果經過 2 秒
        if (m_currentTime - m_beforeTime >=(float)2)
        {
            // 複製敵機
            m_clone = (Transform)Instantiate(t_enemy, newEnemyRespawn, m_enemyRespawn.rotation);

            // 將時間同步，便於下次生成判定
            m_beforeTime = m_currentTime;
        }
    }

    void airPlanControlFunction()
    {

        // 取得左右（A、D）鍵的值
        m_airPlaneHorizontalAxis = Input.GetAxis("Horizontal");

        // 將取得左右鍵的值乘上 time.deltaTime 及 Air Plane 速度
        float m_airPlanePositionX = m_airPlaneHorizontalAxis * Time.deltaTime * m_airPlaneSpeed;

        //m_airPlanePositionX = (m_airPlanePositionX >= (float)5.5) ? ((float)5.5) : ((m_airPlanePositionX <= (float)-5.5) ? ((float)-5.5) : m_airPlanePositionX);

        // 將取得的左右偏移值寫到 Air Plane 玩家物件中，讓之移動。
        t_airPlanePlayer.Translate(m_airPlanePositionX, 0, 0);
        
        // 使用 Mathf.Clamp 方法將 Air Plane 的左右鎖在螢幕內。
        t_airPlanePlayer.position = new Vector3(Mathf.Clamp(t_airPlanePlayer.position.x, (float)-5.5, (float)5.5), (float)0, (float)0);

        // 設定 Air Plane 的動畫，當輸入左值時，顯示向左動畫，無輸入時無動畫，輸入右值時，顯示向右動畫。
        m_airPlaneAnimation[0].SetFloat("AirPlaneDirect", m_airPlaneHorizontalAxis);

        // 當按下滑鼠左鍵時，複製 Air Plane 子彈的預製物件，並且預設會放在 Empty Object 「t_firePosition」的位置。
        if (Input.GetButtonDown("Fire1"))
        {
            // Debug.Log("Fire");
            // Instantiate(要複製的物件, 複製出來後的位置, 複製出來後的旋轉角度)
            Rigidbody t_cloneBullet = (Rigidbody)Instantiate(t_bullet, t_firePosition.position, t_firePosition.rotation);
            //t_cloneBullet.velocity = new Vector3(0, 0, (float)20);
            //t_cloneBullet.velocity = t_firePosition.transform.Translate(0, 0, (float)20);
        }



    }
}
