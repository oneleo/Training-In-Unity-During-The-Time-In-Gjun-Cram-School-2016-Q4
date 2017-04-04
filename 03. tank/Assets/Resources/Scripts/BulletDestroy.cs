using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
	
	public enum type
	{
		player,
		enemy,
	}

	public type bulletType = type.player;
	[SerializeField]
	private float bulletDamage = 50f;

    [SerializeField]
    private GameObject bulletFire;
    private GameObject cloneBullet;

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, (float)3.5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
		if (bulletType == type.player)
		{
			if(other.tag == "enemy")
				{
					other.SendMessage ("ApplyDamage", bulletDamage);
				}
		}

		if (bulletType == type.enemy)
		{
			if(other.tag == "player")
			{
				other.SendMessage ("ApplyDamage", bulletDamage);
			}
		}

        cloneBullet = (GameObject)Instantiate(bulletFire, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
        Debug.Log("BulletFire");
    }
}
