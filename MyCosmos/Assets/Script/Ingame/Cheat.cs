using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    CheckConstellation checkConstellation;
    ConnectStar connectStar;

    void Start()
    {
        checkConstellation = GameObject.Find("CheckConstellation").GetComponent<CheckConstellation>();
        connectStar = GameObject.Find("ConnectStar").GetComponent<ConnectStar>();
    }

    void Update()
    {
#if UNITY_EDITOR
        if(Input.GetKey(KeyCode.T))
        {
            for(int i=0;i<checkConstellation.constell_Database.Length;i++)
            {
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
                    connectStar.LineSpawner(star1Obj, star2Obj);

                }
            }
        }

        else if (Input.GetKey(KeyCode.R))
        {
            GameObject lineGroup=GameObject.Find("LineGroup");
            for(int i=0;i<lineGroup.transform.childCount;i++)
            {
                Destroy(lineGroup.transform.GetChild(i).gameObject);
            }
        }
#endif
    }
}
