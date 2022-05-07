using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckConstellation : ConstellationDatabase
{
    ChapterManage chapterManage;

    List<string> constell_arr = new List<string>();
    List<bool> findCheck=new List<bool>();
    public constell_type[] constell_Database;

    void Start()
    {
        chapterManage = GameObject.Find("ChapterManage").GetComponent<ChapterManage>();

        switch (chapterManage.chapter) //챕터별 별자리
        {
            case "spring":
                constell_Database = base.springConstell;
                break;
            case "summer":
                constell_Database = base.summerConstell;
                break;
            case "autumn":
                constell_Database = base.autumnConstell;
                break;
            case "winter":
                constell_Database = base.winterConstell;
                break;
        }

        for(int i=0;i< constell_Database.Length;i++)
        {
            findCheck.Add(false);
        }
    }

    void LateUpdate()
    {
        for(int i=0;i<constell_Database.Length;i++) //별자리 모두 확인
        {
            if (findCheck[i] == true) continue; //이미 찾은 별자리라면

            bool check = true;
            for(int j=0;j<constell_Database[i].construction.Count;j++) //별자리 구성별 모두 확인
            {
                if(GameObject.Find(constell_Database[i].construction[j])==null)
                {
                    check = false;
                    break;
                }
            }
            if(check==true)
            {
                findCheck[i] = true;
                Debug.Log(constell_Database[i].name);
                break;
            }
        }
        
    }
}
