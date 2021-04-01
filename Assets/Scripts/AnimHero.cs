using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimHero : MonoBehaviour
{
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        StartCoroutine(GetInput());
    }

    IEnumerator GetInput()
    {
        
        anim.SetFloat("BlendX", Input.GetAxis("Horizontal"));
        anim.SetFloat("BlendY", Input.GetAxis("Vertical"));
        
        yield return new WaitForSeconds(0);
        
    }
}
