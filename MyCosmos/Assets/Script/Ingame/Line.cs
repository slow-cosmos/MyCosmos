using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    Material mat;

    public GameObject star1, star2;
    GameObject child;
    BoxCollider col;
    LineRenderer lr;
    Vector3 star1Pos, star2Pos;

    void Start()
    {
        star1Pos = star1.transform.position;
        star2Pos = star2.transform.position;

        lr = gameObject.GetComponent<LineRenderer>();
        col = transform.GetChild(0).gameObject.GetComponent<BoxCollider>();
        
        LineRender();
        LineCollider();
    }

    //라인 그리기
    void LineRender()
    {
        lr.SetWidth(2, 2);
        lr.SetPosition(0, star1Pos);
        lr.SetPosition(1, star2Pos);
        lr.GetComponent<Renderer>().material = mat;
    }

    //콜라이더 씌우기
    void LineCollider()
    {
        col.size = new Vector3(10.0f, 10.0f, Vector3.Distance(star1Pos, star2Pos)-15);
        transform.position = (star2Pos + star1Pos) / 2;
        col.transform.LookAt(star2Pos);
    }
}
