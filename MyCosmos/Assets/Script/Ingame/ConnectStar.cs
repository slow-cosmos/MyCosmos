using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectStar : MonoBehaviour
{
    //https://the-pond.tistory.com/12 선택

    public Camera getCamera;
    RaycastHit hit;
    //LineManage lineManage;
    
    Quaternion curCameraRotation, newCameraRotation;

    public GameObject star1, star2;
    public float selectScale;

    [SerializeField]
    public GameObject Line;

    [SerializeField]
    SelectCircle selectCircle;


    void Start()
    {
        curCameraRotation = getCamera.transform.rotation; //현재 카메라 rotation
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
                    LineDestroy(hit.collider.gameObject);
                }
                
                if(hit.collider.gameObject.tag=="Star")
                {
                    if (star1 == null) // 별1 체크
                    {
                        star1 = hit.collider.gameObject;
                        
                        selectCircle.SpawnCircle(star1);

                        SoundManage.instance.PlayStarSound();
                    }
                    else if (star1 == hit.collider.gameObject) //별1 체크 취소
                    {
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
                        star1 = null;

                        selectCircle.RemoveCircle();
                    }
                    if (star2)
                    {
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
            LineSpawner(star1, star2);

            selectCircle.RemoveCircle();

            star1 = null;
            star2 = null;
        }
    }

    public void LineSpawner(GameObject star1, GameObject star2)
    {
        //하이어라키 순서 정렬
        GameObject startStar = star1.GetComponent<Star>().index < star2.GetComponent<Star>().index ? star1 : star2;
        GameObject endStar = star1.GetComponent<Star>().index < star2.GetComponent<Star>().index ? star2 : star1;

        //라인 이름 바꾸기
        string lineName = startStar.name + "-" + endStar.name;

        //라인 중복 체크
        if (GameObject.Find(lineName)) return;

        //라인 생성
        GameObject line = Instantiate(Line); 

        //하이어라키 순서 정렬
        line.GetComponent<Line>().star1 = startStar;
        line.GetComponent<Line>().star2 = endStar;

        //부모 오브젝트 설정
        line.transform.parent = GameObject.Find("LineGroup").transform;

        //star1star2로 이름변경
        line.gameObject.name = startStar.name +"-"+ endStar.name;

        Debug.Log(line.gameObject.name);
        GameObject.Find("CheckConstellation").GetComponent<CheckConstellation>().Check();
        
    }

    public void LineDestroy(GameObject line)
    {
        Destroy(line);
        Destroy(line.transform.parent.gameObject);
    }
    
}
