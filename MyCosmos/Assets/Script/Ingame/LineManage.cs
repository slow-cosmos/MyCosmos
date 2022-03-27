using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManage : MonoBehaviour
{
    //https://ssscool.tistory.com/347 라인렌더러

    public GameObject Line;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void LineSpawner(GameObject star1, GameObject star2)
    {
        //하이어라키 순서 정렬
        GameObject startStar = star1.transform.GetSiblingIndex() < star2.transform.GetSiblingIndex() ? star1 : star2;
        GameObject endStar = star1.transform.GetSiblingIndex() < star2.transform.GetSiblingIndex() ? star2 : star1;
        
        //라인 중복 체크
        for(int i = 0; i < startStar.transform.childCount; i++)
        {
            GameObject childObject = startStar.transform.GetChild(i).gameObject;
            if (Equals(childObject.GetComponent<Line>().star2,star2)|| Equals(childObject.GetComponent<Line>().star2, star1))
            {
                return;
            }
        }

        GameObject line = Instantiate(Line); //라인 생성

        //하이어라키 순서 정렬
        line.GetComponent<Line>().star1 = startStar;
        line.GetComponent<Line>().star2 = endStar;

        //부모 오브젝트 설정
        line.transform.parent = line.GetComponent<Line>().star1.transform;

        //라인 그리기
        LineRenderer lr = line.GetComponent<LineRenderer>();
        lr.startWidth = .05f;
        lr.endWidth = .05f;
        lr.SetPosition(0, star1.GetComponent<Transform>().position);
        lr.SetPosition(1, star2.GetComponent<Transform>().position);

        //라인 콜리더
        EdgeCollider2D col = line.gameObject.AddComponent<EdgeCollider2D>();
        Vector2[] colliderPoints;
        colliderPoints = col.points;
        colliderPoints[0] = star1.GetComponent<Transform>().position;
        colliderPoints[1] = star2.GetComponent<Transform>().position;
        col.points = colliderPoints;
        col.edgeRadius = 0.1f;
    }

    public void LineDestroy(GameObject line)
    {
        Destroy(line);
    }
}
