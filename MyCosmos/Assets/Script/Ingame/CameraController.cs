using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //https://backback.tistory.com/425

    public float rotSpeed = 1;
    public float zoomSpeed = 10;

    private float rx, ry;
    private Camera camera;

    void Start()
    {
        camera = gameObject.GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Rotate();
        Zoom();
    }

    void Rotate()
    {
        /*if (Input.GetMouseButton(0)) //드래그 회전
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            rx += rotSpeed * my * Time.deltaTime;
            ry += rotSpeed * mx * Time.deltaTime;

            transform.eulerAngles = new Vector3(-rx, ry, 0);
        }*/

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rx -= rotSpeed * Time.deltaTime;
            
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ry -= rotSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rx += rotSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ry += rotSpeed * Time.deltaTime;
        }

        transform.eulerAngles = new Vector3(rx, ry, 0);
    }

    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * -1;
        camera.fieldOfView += scroll;
        if (camera.fieldOfView < 40)
        {
            camera.fieldOfView = 40;
        }
        else if(camera.fieldOfView>80)
        {
            camera.fieldOfView = 80;
        }
        
    }

}
