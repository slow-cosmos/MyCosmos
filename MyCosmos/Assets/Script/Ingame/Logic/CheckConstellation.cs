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

    public constellationInfo[] constellDatabase; // 현재 찾아야 할 별자리 데이터베이스

    bool check;

    void Start()
    {
        //퀘스트 클리어 로드
        DataManage.Instance.LoadChapterData();

        //챕터별 별자리
        switch (ChapterManage.Instance.chapter) 
        {
            case "spring":
                constellDatabase = base.springConstell;
                break;
            case "summer":
                constellDatabase = base.summerConstell;
                break;
            case "autumn":
                constellDatabase = base.autumnConstell;
                break;
            case "winter":
                constellDatabase = base.winterConstell;
                break;
        }
    }

    public void Check()
    {
        for(int i=0;i<constellDatabase.Length;i++) //별자리 모두 확인
        {
            if (constellDatabase[i].check == true) continue; //이미 찾은 별자리라면

            check = true;

            for(int j=0;j<constellDatabase[i].construction.Count;j++) //별자리 구성별 모두 확인
            {
                GameObject temp;
                temp = GameObject.Find(constellDatabase[i].construction[j]);
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
                constellDatabase[i].check = true;

                //찾은 별자리 이름 뜨게하기
                constellText.text = constellDatabase[i].krName;
                Sequence sequence = DOTween.Sequence()
                .Append(constellText.DOFade(1,2f))
                .Append(constellText.DOFade(0,2f));

                //찾은 별자리는 클릭해도 선 안 없어지게
                for (int j = 0; j < constellDatabase[i].construction.Count; j++)
                {
                    Destroy(GameObject.Find(constellDatabase[i].construction[j]).transform.GetChild(0).gameObject.GetComponent<BoxCollider>());
                }

                Debug.Log(constellDatabase[i].name);

                //별자리 찾는 효과음
                SoundManage.Instance.PlayConstellSound();

                //퀘스트 클리어 저장
                DataManage.Instance.SaveChapterData();
            }
        }
    }
}
