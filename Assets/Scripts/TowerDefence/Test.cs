using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject[] enemys;


    void Start()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        for (var i = 0; i < 100; i++)
        {
            Debug.Log(enemys[i]);
        }
    }
}