using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Septentrions : MonoBehaviour
{
    ConstellationDatabase constellationDatabase;
    LineManage lineManage;
    // 북두칠성 그리기
    void Start()
    {
        constellationDatabase = GameObject.Find("ConstellationDatabase").GetComponent<ConstellationDatabase>();
        lineManage = GameObject.Find("LineManage").GetComponent<LineManage>();
    }

    void Update()
    {
        for (int i = 0; i < constellationDatabase.septentrions.construction.Count; i++)
        {
            string star1 = "", star2 = "";
            bool check = false;
            for (int j = 0; j < constellationDatabase.septentrions.construction[i].Length; j++)
            {
                if (constellationDatabase.septentrions.construction[i][j] != '-' && check == false)
                {
                    star1 += constellationDatabase.septentrions.construction[i][j];
                }
                else if (constellationDatabase.septentrions.construction[i][j] != '-' && check == true)
                {
                    star2 += constellationDatabase.septentrions.construction[i][j];
                }
                else
                {
                    check = true;
                }
            }
            GameObject star1Obj, star2Obj;
            star1Obj = GameObject.Find(star1);
            star2Obj = GameObject.Find(star2);
            lineManage.LineSpawner(star1Obj, star2Obj);
        }
    }
}
