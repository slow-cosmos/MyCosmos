using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManage : MonoBehaviour
{
    //https://ssscool.tistory.com/347 라인렌더러

    public GameObject Line;

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
        //line.transform.parent = line.GetComponent<Line>().star1.transform;
        line.transform.parent = GameObject.Find("LineGroup").transform;

        //star1star2로 이름변경
        line.gameObject.name = startStar.name + endStar.name;
        
    }

    public void LineDestroy(GameObject line)
    {
        Destroy(line);
        Destroy(line.transform.parent.gameObject);
    }
}
