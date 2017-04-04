using UnityEngine;
using System.Collections;

public class DestroyGameObject2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // 在物件碰到下方的 Wall2 時
    void OnTriggerEnter(Collider other)
    {
            // 任何只要碰到下方圍牆的物件都要 Destroy
            Destroy(other.gameObject);
        
    }
}
