using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CheckConstellation : ConstellationDatabase
{
    [SerializeField]
    QuestUI questUI;

    [SerializeField]
    Text constellText;

    List<string> constell_arr = new List<string>();
    public constell_type[] constell_Database; // 현재 찾아야 할 별자리 데이터베이스

    bool check;

    void Start()
    {
        //퀘스트 클리어 로드
        DataManage.Instance.LoadChapterData();

        //챕터별 별자리
        switch (ChapterManage.Instance.chapter) 
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
    }

    public void Check()
    {
        for(int i=0;i<constell_Database.Length;i++) //별자리 모두 확인
        {
            if (constell_Database[i].check == true) continue; //이미 찾은 별자리라면

            check = true;

            for(int j=0;j<constell_Database[i].construction.Count;j++) //별자리 구성별 모두 확인
            {
                GameObject temp;
                temp = GameObject.Find(constell_Database[i].construction[j]);
                if (temp)
                {
                    check = true;
                }
                else
                {
                    check = false;
                    break;
                }
            }
            if(check==true)
            {
                constell_Database[i].check = true;

                //찾은 별자리 이름 뜨게하기
                constellText.text = constell_Database[i].krName;
                Sequence sequence = DOTween.Sequence()
                .Append(constellText.DOFade(1,2f))
                .Append(constellText.DOFade(0,2f));

                //찾은 별자리는 클릭해도 선 안 없어지게
                for (int j = 0; j < constell_Database[i].construction.Count; j++)
                {
                    Destroy(GameObject.Find(constell_Database[i].construction[j]).transform.GetChild(0).gameObject.GetComponent<BoxCollider>());
                }

                Debug.Log(constell_Database[i].name);

                //별자리 찾는 효과음
                SoundManage.instance.PlayConstellSound();

                //퀘스트 클리어 저장
                DataManage.Instance.SaveChapterData();
            }
        }
    }
}
