using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyController : MonoBehaviour {

    //public Rigidbody t_cloneBullet;
    [SerializeField]
    private float t_enemySpeedMin = (float)2.5;
    [SerializeField]
    private float t_enemySpddeMax = (float)6;


    [SerializeField]
    private float m_currentTime;
    [SerializeField]
    private float m_beforeTime;
    [SerializeField]
    private float m_cDTime;

    [SerializeField]
    private Rigidbody t_bullet;
    [SerializeField]
    private Transform t_firePosition;

    private Rigidbody m_clone;

    [SerializeField]
    private Image hpBar;
    [SerializeField]
    private float currentHP;
    [SerializeField]
    private float maxHP;

    //private bool currentHPDecrease = false;


    // Use this for initialization
    void Start () {

        // 初始時將時間同步，用於敵機每隔 1.35 秒（m_cDTime）自動發射子彈用
        m_beforeTime = m_currentTime;

        currentHP = maxHP;
        hpBar.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // 記錄目前的時間
        m_currentTime = Time.time;

        // 設定新生成的敵機速度都要不一樣，介於 t_enemySpeedMin 和 t_enemySpddeMax 之間隨機產生
        this.transform.Translate(0, 0, Random.Range(t_enemySpeedMin, t_enemySpddeMax)*Time.deltaTime);

        enemyFire();

        
        hpBar.fillAmount = currentHP / maxHP;
        
        if (currentHP != maxHP)
        {
            hpBar.gameObject.SetActive(true);
        }
        

        if(currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void enemyFire()
    {
        // 如果隔了 m_cDTime（1.35 秒）後
        if (m_currentTime - m_beforeTime >= (float)m_cDTime)
        {
            // 生成新的子彈，其初始位置為 t_firePosition.position，初始旋轉值為 t_firePosition.rotation
            // Instantiate(欲複製的物件, 複製出來的物件位置, 複製出來的物件旋轉值);
            Rigidbody t_cloneBullet = (Rigidbody)Instantiate(t_bullet, t_firePosition.position, t_firePosition.rotation);

            // 將時間重新同步，便於下次生成敵機子彈判定
            m_beforeTime = m_currentTime;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }

    void enemyDamage(float damage)
    {
        currentHP = currentHP - damage;
        //currentHPDecrease = true;
    }
}
