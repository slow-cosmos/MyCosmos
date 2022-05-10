using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStar : MonoBehaviour
{
    //https://the-pond.tistory.com/12 선택

    public Camera getCamera;
    RaycastHit hit;
    LineManage lineManage;

    public GameObject star1, star2;

    void Start()
    {
        lineManage = GameObject.Find("LineManage").GetComponent<LineManage>();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
  
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.gameObject.tag=="Line")
                {
                    lineManage.LineDestroy(hit.collider.gameObject);
                }
                
                if(hit.collider.gameObject.tag=="Star")
                {
                    if (star1 == null)
                    { //별1 체크
                        star1 = hit.collider.gameObject;
                        //star1.GetComponent<Renderer>().material.color = Color.red;
                        //Debug.Log("check star1");
                    }
                    else if (star1 == hit.collider.gameObject) //별1 체크 취소
                    {
                        //star1.GetComponent<Renderer>().material.color = Color.clear;
                        star1 = null;
                        //Debug.Log("no check star1");
                    }
                    else if (star2 == null) //별2 체크
                    {
                        star2 = hit.collider.gameObject;
                        //star2.GetComponent<Renderer>().material.color = Color.clear;
                        //Debug.Log("check star2");
                    }
                    else if (star2 == hit.collider.gameObject) //별2 체크 취소
                    {
                        //star2.GetComponent<Renderer>().material.color = Color.clear;
                        star2 = null;
                        //Debug.Log("no check star2");
                    }
                }
                
            }
            else //다른 데 클릭하면 선택 취소
            {
                if (star1)
                {
                    //star1.GetComponent<Renderer>().material.color = Color.clear;
                    star1 = null;
                    //Debug.Log("no check star1");
                }
                if (star2)
                {
                    //star2.GetComponent<Renderer>().material.color = Color.clear;
                    star2 = null;
                    //Debug.Log("no check star2");
                }

            }
        }

        if(star1 != null && star2 != null) //별 잇기
        {
            lineManage.LineSpawner(star1, star2);

            //star1.GetComponent<Renderer>().material.color = Color.clear;
            //star2.GetComponent<Renderer>().material.color = Color.clear;
            star1 = null;
            star2 = null;
        }
    }

    
}
