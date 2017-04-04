using UnityEngine;
using System.Collections;

public class CutFruit : MonoBehaviour {
    
    private Component[] fruitChild;

    public static int CutPoint = 0;

    [SerializeField]
        private GameObject splash;
        private GameObject clone;
	// Use this for initialization
	void Start () {
        //fruitChild = GetComponentsInChildren<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "fruit")
        {
            CutPoint = CutPoint +100;
            other.GetComponent<Collider>().isTrigger = false;
            fruitChild = other.GetComponentsInChildren<Rigidbody>();

            for (int i = 0; i < fruitChild.Length; i++)
            {
                fruitChild[i].GetComponentInChildren<Rigidbody>().isKinematic = false;
                fruitChild[i].GetComponentInChildren<Collider>().isTrigger = false;
            }
            other.tag = "Untagged";
            clone = (GameObject)Instantiate(splash,other.transform.position,other.transform.rotation);
        }
    }
}
