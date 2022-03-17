using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetStar : MonoBehaviour
{
    //https://the-pond.tistory.com/12 선택
    //https://ssscool.tistory.com/347 라인렌더러

    public Camera getCamera;
    private RaycastHit hit;

    LineRenderer lr;
    Vector3 star1Pos, star2Pos;
    GameObject star1, star2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                if(star1==null) {
                    star1 = hit.collider.gameObject;
                    star1.GetComponent<Renderer>().material.color = Color.red;
                }
                else
                {
                    star2 = hit.collider.gameObject;
                    star2.GetComponent<Renderer>().material.color = Color.red;
                }
            }
            else
            {
                if (star1)
                {
                    star1.GetComponent<Renderer>().material.color = Color.black;
                    star1 = null;
                    Debug.Log("no check star1");
                }
                if (star2)
                {
                    star2.GetComponent<Renderer>().material.color = Color.black;
                    star2 = null;
                    Debug.Log("no check star2");
                }

            }
        }
    }
}
