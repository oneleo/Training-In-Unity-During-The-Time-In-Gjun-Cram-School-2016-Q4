using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerDamage : MonoBehaviour {
    
    public Image playerHPUI;

    public float maxHP = (float)100;
    public float currentHP = (float)100;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playerHPUI.fillAmount = currentHP / maxHP;

        if (currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void ApplyDamage(float damage)
    {
        currentHP = currentHP - damage;
    }
}
