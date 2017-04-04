using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    //public Rigidbody t_cloneBullet;
    public float t_bulletSpeed = 3;
    private float enemyBulletDamage = (float)10;
    private float playerBulletDamage = (float)45;


    public enum bulletType
    {
        enemyBullet,
        playerBullet,
    }

    public bulletType bulletMode = bulletType.playerBullet;


    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {

        if(bulletMode== bulletType.playerBullet)
        {
            t_bulletSpeed = (float)3;
        }
        else if (bulletMode == bulletType.enemyBullet)
        {
            t_bulletSpeed = (float).5;
        }
            this.transform.Translate(0, 0, t_bulletSpeed);
    }

    void OnTriggerEnter(Collider other)
    {

        if (bulletMode == bulletType.playerBullet)
        {
            /*
            if (other.tag == "Enemy" || other.tag =="Bullet")
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
            */
            if (other.tag == "Enemy")
            {
                other.SendMessage("enemyDamage", playerBulletDamage);
                Destroy(this.gameObject);

            }
            if (other.tag == "Bullet")
            {
                Destroy(other.gameObject);
            }


        }
        else if (bulletMode == bulletType.enemyBullet)
        {
            /*
            if (other.tag == "Player" || other.tag == "Bullet")
            {
                Destroy(other.gameObject);
            }
            */
            if (other.tag == "Player")
            {
                other.SendMessage("ApplyDamage", enemyBulletDamage);
                Destroy(this.gameObject);

            }
            if (other.tag == "Bullet")
            {
                Destroy(other.gameObject);
            }
        }

        

    }

}
