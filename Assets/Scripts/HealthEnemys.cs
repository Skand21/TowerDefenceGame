using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Контролирует здоровье миньоноа - если оно отрицательное, то миньон удаляется со сцены */

public class HealthEnemys : MonoBehaviour
{
    public Move_Sphere Move_SphereScript;
    public Hero_lvl1 Hero_lvl1Script;
    public GameObject Hero;
    int health;
    
    void Start()
    {
        health = Hero_lvl1Script.health;
    }


    void OnCollisionExit(Collision coll)
    {
        if (coll.transform.gameObject.CompareTag("Bullet"))
        {

            if (health <= 0)
            {
                Destroy(Hero);
            }
            else
            {
                health = health - Move_SphereScript.damagebutton;
            }
        }
    }

}
