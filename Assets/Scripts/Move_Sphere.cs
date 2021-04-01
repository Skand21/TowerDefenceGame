using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Задает характеристики и вектор пули
* Пуля уничтожается, когда касается НЕ миньона */


public class Move_Sphere : MonoBehaviour
{
    public GameObject Sphere;
    public Vector3 HeroPoint;
    public float speed;
    bool switcher;

    public int damagebutton = 100; // Урон, который наносит пуля

    void Update()
    {

        if (switcher == false) // Пока шар не прилетел к цели
        {
            transform.position = Vector3.MoveTowards(transform.position, HeroPoint, Time.deltaTime * speed);
            switcher = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
