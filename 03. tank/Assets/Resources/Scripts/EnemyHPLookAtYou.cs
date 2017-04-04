using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPLookAtYou : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    // Use this for initialization
    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(player);
    }
}
