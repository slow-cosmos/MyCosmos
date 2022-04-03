using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //https://backback.tistory.com/425
    float rx;
    float ry;
    public float rotSpeed = 200;

    void Rotate()
    {
        if (Input.GetMouseButton(0))
        {
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");

            rx += rotSpeed * my * Time.deltaTime;
            ry += rotSpeed * mx * Time.deltaTime;

            transform.eulerAngles = new Vector3(-rx, ry, 0);
        }
    }

    public void LateUpdate()
    {
        Rotate();
    }
}
