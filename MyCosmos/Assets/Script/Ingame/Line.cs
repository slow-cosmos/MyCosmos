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
    Vector3 star1Pos, star2Pos;

    // Start is called before the first frame update
    void Start()
    {
        star1Pos = star1.transform.position;
        star2Pos = star2.transform.position;
        col = transform.GetChild(0).gameObject.GetComponent<BoxCollider>();

        LineRender();
        LineCollider();
        
    }

    void LineCollider()
    {
        col.size = new Vector3(5.0f, 5.0f, Vector3.Distance(star1Pos, star2Pos)-5);
        transform.position = (star2Pos + star1Pos) / 2;
        col.transform.LookAt(star2Pos);
    }

    void LineRender()
    {
        //라인 그리기
        LineRenderer lr = gameObject.GetComponent<LineRenderer>();
        lr.SetWidth(2, 2);
        lr.SetPosition(0, star1Pos);
        lr.SetPosition(1, star2Pos);
        lr.GetComponent<Renderer>().material = mat;
    }
}
