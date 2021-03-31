using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Raycast : MonoBehaviour
{
    public Move_Sphere Script_sphere; // Скрипт сферы
    public GameObject Sphere; // Префаб снаряда
    public GameObject Burrel0; // Конец дула пушки
    public GameObject Burrel_L; // Левая сторона турели
    public GameObject Burrel_R; // Правая сторона турели
    public GameObject Gun; // Турель
    public float Len_L; // Расстояние от левого дула
    public float Len_R; // Расстояние от правого дула
    bool triggerShoot;
    public AudioSource ShootingSound;

    public GameObject[] enemys; // Массив вражеских сущеатв - объектов
    public GameObject min_goal; // Ближайшая цель для турели
    int numbers_enemies = 10; // Количество противников


    /* Здесь находятся параметры
     * которые будут меняться, добавляться
     * или внедряться в из других скриптов */
    
    public int time = 1;
    public int speed = 500;
    public string colour = "0";
    
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();

        enemys = GameObject.FindGameObjectsWithTag("Enemy");

    }

    void FixedUpdate()
    {
        
        Rotating();
        Shooting(time);

    }


    void Shooting(int time)
    {
        
        Ray ray = new Ray(transform.position, transform.forward); // Задаём Райкаст
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 100);

        if (hit.collider.transform.gameObject.CompareTag("Enemy")) // Если луч попадает в игрока
        {
            if (triggerShoot == false)

            {
                triggerShoot = true;
                Script_sphere.HeroPoint = min_goal.transform.position; // Передается координата Hero в скрипт на сфере

                Invoke("Short", time);
            }
        }
    }



    /* Обеспечивает стрельбу */
    void Short()
    {
        AudioSource AS = GetComponent<AudioSource>();

        Transform BulletInstance = Instantiate(Sphere.transform, transform.position, Quaternion.identity);
        BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * speed);

        triggerShoot = false;
        ShootingSound.Play();
    }


    void Rotating()
    {
        /* Производит кручение турели */
        
            AudioSource AS = GetComponent<AudioSource>();

            Len_L = Vector3.Distance(Burrel_L.transform.position, min_goal.transform.position);
            Len_R = Vector3.Distance(Burrel_R.transform.position, min_goal.transform.position);

            if (Len_R > Len_L)
            {
                Gun.transform.Rotate(0, -1, 0, Space.Self); // Турель крутится против часовой
            }

            else if (Len_R < Len_L)
            {
                Gun.transform.Rotate(0, 1, 0, Space.Self); // Турель крутится по часовой
            }
    }

    private void OnTriggerEnter(Collider col)
    {

        /* Ищем ближайшую цель*/

        for (var i = 0; i < numbers_enemies; i++)
        {
            if (Vector3.Distance(Burrel_L.transform.position, min_goal.transform.position) > Vector3.Distance(Burrel_L.transform.position, enemys[i].transform.position))
            {
                min_goal = enemys[i]; // Минимальное расстояние обновлено
            }
        }
    }
}