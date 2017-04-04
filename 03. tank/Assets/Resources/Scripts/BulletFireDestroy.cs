using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFireDestroy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Destroy(this.gameObject, (float)3);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
