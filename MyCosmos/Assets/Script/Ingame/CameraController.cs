﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 1;
    [SerializeField] private float zoomSpeed = 10;

    [SerializeField] private Camera camera;
    
    [SerializeField] private GameObject selectCircle;

    private float rx, ry;

    private bool isEnabled = true;
    public bool IsEnabled
    {
        set
        {
            isEnabled = value;
        }
    }

    void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            rotSpeed = 3;
            zoomSpeed = 0.08f;
        }
    }

    void Update()
    {
        if(isEnabled && GameManage.Instance.gameState == GameState.PLAY)
        {
            Rotate();
            Zoom();
        }
    }

    void Rotate()
    {
        if(Application.platform == RuntimePlatform.Android) //터치 회전
        {
            if(Input.touchCount==1 && Input.GetTouch(0).phase==TouchPhase.Moved)
            {
                float mx = Input.GetAxis("Mouse X");
                float my = Input.GetAxis("Mouse Y");

                mx = Input.touches[0].deltaPosition.x;
                my = Input.touches[0].deltaPosition.y;

                rx += rotSpeed * my * Time.deltaTime * (camera.fieldOfView * 0.01f);
                ry -= rotSpeed * mx * Time.deltaTime * (camera.fieldOfView * 0.01f);

                if (rx < -90) rx = -90;
                if (rx > 0) rx = 0;

                transform.eulerAngles = new Vector3(-rx, ry, 0);
            }
        }

        else if (Input.GetMouseButton(0)) //드래그 회전
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            rx += rotSpeed * my * Time.deltaTime * (camera.fieldOfView * 0.01f);
            ry -= rotSpeed * mx * Time.deltaTime * (camera.fieldOfView * 0.01f);

            if (rx < -90) rx = -90;
            if (rx > 0) rx = 0;

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
            if (rx > 0) rx = 0;
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
            else if (camera.fieldOfView > 90) //줌아웃
            {
                camera.fieldOfView = 90;
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
            else if (camera.fieldOfView > 90) //줌아웃
            {
                camera.fieldOfView = 90;
            }
        }

        float circleSize = camera.fieldOfView * 0.01f;
        selectCircle.transform.localScale = new Vector3(circleSize, circleSize, circleSize);
        
    }
}
