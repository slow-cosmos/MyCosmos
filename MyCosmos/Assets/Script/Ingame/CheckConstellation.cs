using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckConstellation : ConstellationDatabase
{
    ChapterManage chapterManage;

    [SerializeField]
    GameObject questGroup;

    [SerializeField]
    Text constellText;

    List<string> constell_arr = new List<string>();
    //List<bool> findCheck=new List<bool>();
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

        /*for(int i=0;i< constell_Database.Length;i++)
        {
            findCheck.Add(false);
        }*/
    }

    void LateUpdate()
    {
        for(int i=0;i<constell_Database.Length;i++) //별자리 모두 확인
        {
            if (constell_Database[i].check == true) continue; //이미 찾은 별자리라면

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
                constell_Database[i].check = true;
                questGroup.transform.Find(constell_Database[i].name).GetComponent<Toggle>().isOn = true; //별자리를 찾으면 체크
                StartCoroutine(FadeInConstellText(constell_Database[i].krName)); //찾은 별자리 이름 뜨게하기

                for (int j = 0; j < constell_Database[i].construction.Count; j++) //찾은 별자리는 클릭해도 선 안 없어지게
                {
                    //Destroy(GameObject.Find(constell_Database[i].construction[j]).transform.GetChild(0).gameObject.GetComponent<BoxCollider>());
                }

                Debug.Log(constell_Database[i].name);
                break;
            }
        }
    }

    IEnumerator FadeInConstellText(string name)
    {
        constellText.text = name;

        while (constellText.color.a < 1.0f)
        {
            constellText.color = new Color(1,1,1, constellText.color.a + (Time.deltaTime / 2f));
            yield return null;
        }
        
        StartCoroutine(FadeOutConstellText(name));
    }

    IEnumerator FadeOutConstellText(string name)
    {
        while (constellText.color.a > 0.0f)
        {
            constellText.color = new Color(1, 1, 1, constellText.color.a - (Time.deltaTime / 2f));
            yield return null;
        }
    }
}
