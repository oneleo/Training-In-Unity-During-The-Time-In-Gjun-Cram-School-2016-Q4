using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Transform[] m_fruitRespawn;
    [SerializeField]
    private int m_PosID;

    [SerializeField]
    private Rigidbody[] t_Fruit;
    private int t_FruitID;

    [SerializeField]
    private float m_currentTime;

    [SerializeField]
    private float m_beforeTime;

    [SerializeField]
    private float m_cDTime;

    private Rigidbody m_clone;

    private float power;
    [SerializeField]
    private float maxPower;
    [SerializeField]
    private float minPower;

    private float x;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minX;
    [SerializeField]
    private Camera camera;
    private Ray ray;
    private RaycastHit hit;
    [SerializeField]
    private Transform finger;
    [SerializeField]
    private Transform fingerResetPoint;

    [SerializeField]
    private Text ScorePoint;
    private int CutPoint;
    private int DiePoint;

    void CreateRay()
    {

        if (Input.GetButton("Fire1"))
        {
            ray = camera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * (float)20, Color.red);
            if (Physics.Raycast(ray, out hit, 50))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.green);
                finger.position = new Vector3(hit.point.x, hit.point.y, 0);
                finger.gameObject.GetComponent<TrailRenderer>().enabled = true;
            }
        }
        else
        {
            finger.position = fingerResetPoint.position;
            finger.gameObject.GetComponent<TrailRenderer>().enabled = false;

        }



        /*
                if (Input.GetButton("Fire1")) { 
                ray = camera.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * (float)20, Color.red);
                if (Physics.Raycast(ray,out hit,50)) {

                        if(hit.collider.tag == "remotePlane")
                        {

                            Debug.DrawLine(ray.origin, hit.point, Color.green);
                            finger.position = hit.point;
                        }

                }
                }

    */

    }

    // Use this for initialization
    void Start()
    {
        /*
        // 初始時將時間同步，用於敵機每隔 1.35 秒（m_cDTime）自動發射子彈用
        m_beforeTime = m_currentTime;
        */

        // 初始時將時間同步，用於每隔 2 秒產生敵機
        m_beforeTime = m_currentTime;

        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        finger.position = fingerResetPoint.position;
        finger.gameObject.GetComponent<TrailRenderer>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        fruitRespawn();
        CreateRay();
        CutPoint = CutFruit.CutPoint;
        DiePoint = DestroyFruit.diePoint;
        ScorePoint.text = (CutPoint + DiePoint).ToString();
    }


    // 用於敵機的生成
    void fruitRespawn()
    {
        // 記錄目前的時間
        m_currentTime = Time.time;

        power = Random.Range(minPower, maxPower);
        x = Random.Range(minX, maxX);
        m_PosID = Random.Range(0, m_fruitRespawn.Length);
        t_FruitID = Random.Range(0, t_Fruit.Length);

        //Vector3 newEnemyRespawn = new Vector3(Random.Range((float)-5.5, (float)5.5), m_enemyRespawn.position.y, m_enemyRespawn.position.z);

        // 如果經過 2 秒
        if (m_currentTime - m_beforeTime >= m_cDTime)
        {
            // 複製敵機
            m_clone = (Rigidbody)Instantiate(t_Fruit[t_FruitID], m_fruitRespawn[m_PosID].position, m_fruitRespawn[m_PosID].rotation);
            m_clone.velocity = transform.TransformDirection(x, power, 0);

            // 將時間同步，便於下次生成判定
            m_beforeTime = m_currentTime;
        }
    }

    /*
void enemyFire()
{
    // 如果隔了 m_cDTime（1.35 秒）後
    if (m_currentTime - m_beforeTime >= (float)m_cDTime)
    {
        // 生成新的子彈，其初始位置為 t_firePosition.position，初始旋轉值為 t_firePosition.rotation
        // Instantiate(欲複製的物件, 複製出來的物件位置, 複製出來的物件旋轉值);
        Rigidbody t_cloneBullet = (Rigidbody)Instantiate(t_fruit, t_firePosition.position, t_firePosition.rotation);

        // 將時間重新同步，便於下次生成敵機子彈判定
        m_beforeTime = m_currentTime;

    }
}*/

}
