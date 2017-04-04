using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField]
    private float attRadius = 150;
    [SerializeField]
    private float fireRadius = 75;

    [SerializeField]
    private Transform player;
    private float playdis;

    [SerializeField]
    private float mSpeed = 6f;

    [SerializeField]
    private Transform turret;
    [SerializeField]
    private float cdTime = 3.5f;
    private float curTime;
    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    private float bulletSpeed = 400f;
    [SerializeField]
    private Transform firePos;

    [SerializeField]
    private float maxHP = 100f;
    private float curHP;

    [SerializeField]
    private GameObject tankBroke;

    [SerializeField]
    private Image HPImage;

    public Transform[] wayPoint;
    private int wpCount;
    private int wpID;
    private float wpDis;


    // Use this for initialization
    void Start()
    {

        curHP = maxHP;
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        }

        wpCount = GameObject.FindWithTag("WG01").GetComponent<Transform>().childCount;
        wayPoint = new Transform[wpCount];
        for (int i = 0; i < wpCount; i++)
        {
            wayPoint[i] = GameObject.Find("Way0" + (i).ToString()).GetComponent<Transform>();
        }
        wpID = Random.Range(0, wayPoint.Length);

    }

    void FixedUpdate()
    {
        if (curTime > 0f)
        {
            curTime -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        wpDis = Vector3.Distance(wayPoint[wpID].position, this.transform.position);

        playdis = Vector3.Distance(player.position, this.transform.position);

        //Debug.Log(playdis);
        Behaviour();
        HPImage.fillAmount = curHP / maxHP;
        if (curHP >= maxHP)
        {
            curHP = maxHP;
        }
        if (curHP <= maxHP)
        {
            die();
        }

    }
    void die()
    {
        if (curHP <= 0f)
        {
            GameObject clone = (GameObject)Instantiate(tankBroke, this.transform.position, this.transform.rotation);
            Camera.main.transform.parent = null;
            Destroy(this.gameObject);
        }
    }

    void ApplyDamage(float damage)
    {
        curHP -= damage;
        //Debug.Log(damage);
    }

    void Behaviour()
    {
        if (playdis < fireRadius)
        {
            Fire();
        }
        else if (playdis < attRadius && playdis > fireRadius)
        {
            this.transform.LookAt(player);
            Move();
        }
        else
        {
            Patrol();
        }
    }
    void Fire()
    {
        turret.LookAt(player);
        if (curTime <= 0f)
        {
            Rigidbody clone = (Rigidbody)Instantiate(bullet, firePos.position, firePos.rotation);
            clone.velocity = firePos.TransformDirection(new Vector3(0, 0, bulletSpeed));
            curTime = cdTime;
        }

        //Debug.Log("開火");
    }

    void Move()
    {
        //this.transform.LookAt(player);
        this.transform.Translate(0, 0, mSpeed * Time.deltaTime);
    }

    void Patrol()
    {
        if (wpDis < 2f)
        {
            wpID = (wpID + 1) % wpCount;
        }
        this.transform.LookAt(wayPoint[wpID]);
        Move();
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fireRadius);
    }

}
