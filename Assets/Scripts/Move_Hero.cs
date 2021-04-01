using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Hero : MonoBehaviour
{
    public GameObject player;
    public GameObject Camera;
    public GameObject VisibilityFloor;
    private Vector3 lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)
    float camSens = 0.2f; //How sensitive it with mouse


    public int speedRotation = 3;
    public int speed = 5;
    public int jumpSpeed = 50;
    

    void Start()
    {
        player = (GameObject)this.gameObject;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position += player.transform.forward * speed * 5 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position -= player.transform.forward * speed * 5 * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Rotate(Vector3.down * speedRotation);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Rotate(Vector3.up * speedRotation);
        }


        // Если floor мешает, то визуально он отключается

        /***if (Camera.transform.position.y < 0)
        {
            VisibilityFloor.SetActive(false);
        }
        else
        {
            VisibilityFloor.SetActive(true);
        }

        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        //Mouse  camera angle done.  
        **/
    }
}