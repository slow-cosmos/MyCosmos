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

    void Update()
    {
        Rotate();
        Zoom();
    }

    void Rotate()
    {
        if (Input.GetMouseButton(0)) //드래그 회전
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            rx += rotSpeed * my * Time.deltaTime;
            ry -= rotSpeed * mx * Time.deltaTime;

            transform.eulerAngles = new Vector3(-rx, ry, 0);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) //방향키 회전
        {
            rx -= rotSpeed * Time.deltaTime;
            if (rx < -90) rx = -90;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            ry -= rotSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rx += rotSpeed * Time.deltaTime;
            if (rx > 90) rx = 90;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            ry += rotSpeed * Time.deltaTime;
        }

        transform.eulerAngles = new Vector3(rx, ry, 0);
    }

    void Zoom()
    {
        if (Input.touchCount == 2) //두 손가락 터치 줌인
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            camera.fieldOfView += deltaMagnitudeDiff * zoomSpeed;
            camera.fieldOfView = Mathf.Clamp(camera.fieldOfView, 0.1f, 179.9f);

            if (camera.fieldOfView < 20) //줌인 
            {
                camera.fieldOfView = 20;
            }
            else if (camera.fieldOfView > 80) //줌아웃
            {
                camera.fieldOfView = 80;
            }
        }

        else
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * -1;
            camera.fieldOfView += scroll;
            if (camera.fieldOfView < 20) //줌인 
            {
                camera.fieldOfView = 20;
            }
            else if (camera.fieldOfView > 80) //줌아웃
            {
                camera.fieldOfView = 80;
            }
        }
        
    }

}
