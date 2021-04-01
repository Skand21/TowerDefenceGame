using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (transform.position.y <= 2.5) // Уничтожает шар, если он коснулся пола
        {
            Destroy(gameObject);
        }
    }
}
