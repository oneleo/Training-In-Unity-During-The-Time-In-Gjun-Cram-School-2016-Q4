using UnityEngine;
using System.Collections;

public class DestroyFruit : MonoBehaviour {


public static int diePoint = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "fruit"){
			diePoint = diePoint - 45;
		}
		Debug.Log("DD");
		Destroy(other.gameObject);
		
	}
}
