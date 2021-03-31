using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Sphere : MonoBehaviour
{
    public GameObject Sphere;
    public Vector3 HeroPoint;
    public float speed;
    public int i = 0;

    void Update()
    {
        if (i == 0)// Пока шар не прилетел к цели
        {
            transform.position = Vector3.MoveTowards(transform.position, HeroPoint, Time.deltaTime * speed);
            i = 1;
        }

        if (transform.position.y <= 2.5)// Уничтожает шар, если он коснулся пола
        {
            Destroy(gameObject);
        }
    }
}
