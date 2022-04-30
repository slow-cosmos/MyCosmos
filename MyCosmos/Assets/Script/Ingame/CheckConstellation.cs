using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckConstellation : MonoBehaviour
{
    ConstellationDatabase cdb;
    List<bool> findCheck=new List<bool>();

    void Start()
    {
        cdb = GameObject.Find("ConstellationDatabase").GetComponent<ConstellationDatabase>();
        for(int i=0;i< cdb.constell_Database.Length;i++)
        {
            findCheck.Add(false);
        }
    }

    void LateUpdate()
    {
        for(int i=0;i<cdb.constell_Database.Length;i++) //별자리 모두 확인
        {
            if (findCheck[i] == true) continue; //이미 찾은 별자리라면

            bool check = true;
            for(int j=0;j<cdb.constell_Database[i].construction.Count;j++) //별자리 구성별 모두 확인
            {
                if(GameObject.Find(cdb.constell_Database[i].construction[j])==null)
                {
                    check = false;
                    break;
                }
            }
            if(check==true)
            {
                findCheck[i] = true;
                Debug.Log(cdb.constell_Database[i].name);
                break;
            }
        }
    }
}
