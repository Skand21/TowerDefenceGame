using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim_Turret : MonoBehaviour
{
    public AudioSource RotatingSound;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Hero"))
        {
            anim.SetBool("Sleep", false);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Hero"))
        {
            anim.SetBool("Sleep", true);
        }
    }
}
