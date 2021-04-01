using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{


    public GameObject i;
    public Color x;
    
    public void CAT()
    {

        x = Color.blue;
        i.GetComponent<Renderer>().material.color = x;
        
    }



 
}