using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStar : MonoBehaviour
{
    //https://the-pond.tistory.com/12 선택

    public Camera getCamera;
    RaycastHit hit;
    LineManage lineManage;
    SelectCircle selectCircle;

    Quaternion curCameraRotation, newCameraRotation;

    public GameObject star1, star2;
    public float selectScale;


    void Start()
    {
        lineManage = GameObject.Find("LineManage").GetComponent<LineManage>();
        curCameraRotation = getCamera.transform.rotation; //현재 카메라 rotation
        selectCircle = GameObject.Find("WorldSpaceCanvas").transform.Find("SelectCircle").GetComponent<SelectCircle>();
    }

    void Update()
    {
        newCameraRotation = getCamera.transform.rotation;

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
                        
                        //star1.transform.Find("Select").gameObject.SetActive(true);
                        //selectScale = 30 / star1.transform.localScale.x;
                        //star1.transform.Find("Select").localScale = new Vector3(selectScale, selectScale, selectScale);

                        selectCircle.SpawnCircle(star1);

                        SoundManage.instance.PlayStarSound();
                    }
                    else if (star1 == hit.collider.gameObject) //별1 체크 취소
                    {
                        //star1.transform.Find("Select").gameObject.SetActive(false);
                        star1 = null;

                        selectCircle.RemoveCircle();
                    }
                    else if (star2 == null) //별2 체크
                    {
                        star2 = hit.collider.gameObject;

                        SoundManage.instance.PlayStarSound();
                    }
                    else if (star2 == hit.collider.gameObject) //별2 체크 취소
                    {
                        //star2.transform.Find("Select").gameObject.SetActive(false);
                        star2 = null;

                        selectCircle.RemoveCircle();
                    }
                }
                
            }
            else //다른 데 클릭하면 선택 취소
            {
                if(curCameraRotation==newCameraRotation) //카메라의 rotate가 같다면 선택 취소
                {
                    if (star1)
                    {
                        //star1.transform.Find("Select").gameObject.SetActive(false);
                        star1 = null;

                        selectCircle.RemoveCircle();
                    }
                    if (star2)
                    {
                        //star2.transform.Find("Select").gameObject.SetActive(false);
                        star2 = null;

                        selectCircle.RemoveCircle();
                    }
                }
                else
                {
                    curCameraRotation = newCameraRotation;
                }
            }
        }

        if(star1 != null && star2 != null) //별 잇기
        {
            lineManage.LineSpawner(star1, star2);

            //star1.transform.Find("Select").gameObject.SetActive(false);
            //star2.transform.Find("Select").gameObject.SetActive(false);

            selectCircle.RemoveCircle();

            star1 = null;
            star2 = null;
        }
    }

    
}
