using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectStar : MonoBehaviour
{
    public Camera getCamera;
    RaycastHit hit;
    
    Quaternion curCameraRotation, newCameraRotation;

    public GameObject star1, star2;
    public float selectScale;

    [SerializeField]
    public GameObject Line;

    [SerializeField]
    SelectCircle selectCircle;

    CheckConstellation checkConstellation;

    void Start()
    {
        MakeConstellation();
        curCameraRotation = getCamera.transform.rotation; //현재 카메라 rotation
    }

    void Update()
    {
        newCameraRotation = getCamera.transform.rotation;

        if (Input.GetMouseButtonUp(0) && GameManage.Instance.gameState == GameState.PLAY)
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

                        SoundManage.Instance.PlayStarSound();
                    }
                    else if (star1 == hit.collider.gameObject) //별1 체크 취소
                    {
                        star1 = null;

                        selectCircle.RemoveCircle();
                    }
                    else if (star2 == null) //별2 체크
                    {
                        star2 = hit.collider.gameObject;

                        SoundManage.Instance.PlayStarSound();
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

    // 클리어 된 퀘스트는 별자리 그리기
    public void MakeConstellation()
    {
        checkConstellation = GameObject.Find("CheckConstellation").GetComponent<CheckConstellation>();
        for(int i=0;i<checkConstellation.constell_Database.Length;i++)
        {
            if(checkConstellation.constell_Database[i].check == false) continue;
            for(int j=0;j<checkConstellation.constell_Database[i].construction.Count;j++)
            {
                string star1="", star2="";
                bool check = false;
                for (int k = 0; k < checkConstellation.constell_Database[i].construction[j].Length; k++)
                {
                    if (checkConstellation.constell_Database[i].construction[j][k] != '-' && check == false)
                    {
                        star1 += checkConstellation.constell_Database[i].construction[j][k];
                    }
                    else if (checkConstellation.constell_Database[i].construction[j][k] != '-' && check == true)
                    {
                        star2 += checkConstellation.constell_Database[i].construction[j][k];
                    }
                    else
                    {
                        check = true;
                    }
                }
                GameObject star1Obj, star2Obj;
                star1Obj = GameObject.Find(star1);
                star2Obj = GameObject.Find(star2);
                LineSpawner(star1Obj, star2Obj, false);

                //찾은 별자리는 클릭해도 선 안 없어지게
                Destroy(GameObject.Find(checkConstellation.constell_Database[i].construction[j]).transform.GetChild(0).gameObject.GetComponent<BoxCollider>());
            }
        }
    }

    public void LineSpawner(GameObject star1, GameObject star2, bool checkFlag=true)
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

        //Debug.Log(line.gameObject.name);

        if(checkFlag == false) return;

        //선 생성할 때마다 별자리 확인하기
        checkConstellation.GetComponent<CheckConstellation>().Check();
    }

    public void LineDestroy(GameObject line)
    {
        Destroy(line);
        Destroy(line.transform.parent.gameObject);
    }
    
}
