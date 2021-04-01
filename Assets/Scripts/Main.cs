using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/* Работа с кнопками 
 * создаёт турели разных типов
*/

public class Main : MonoBehaviour
{
    public GameObject Turett; // Перфаб турели
    GameObject NewTurret; // Новая турель

    float x, z;
    private bool swicher = false;

    void FixedUpdate()
    {
        if (swicher == true)
        {

            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;

            /* Перемещаем турель, пока не будет нажата кнопка (0)*/
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                Turett.transform.position = hit.point;
                x = hit.point.x;
                z = hit.point.z;

                NewTurret.transform.position = new Vector3(x, 10, z);

                if (Input.GetMouseButtonDown(0))
                    swicher = false;
            }
        }
    }


    public void OnClickCreateTurett() // По нажаии кнопку (0) создается турель
    {
        swicher = true;
        
        NewTurret = Instantiate(Turett, transform.position, transform.rotation);
        
    }
}
