using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManage : MonoBehaviour
{
    [SerializeField]
    GameObject clearObject;

    CheckConstellation checkConstellation;

    void Start()
    {
        checkConstellation = GameObject.Find("CheckConstellation").GetComponent<CheckConstellation>();
    }

    void Update()
    {
        CheckChapterClear();
    }

    void CheckChapterClear()
    {
        bool check = true;
        for (int i = 0; i < checkConstellation.constellDatabase.Length; i++)
        {
            if(checkConstellation.constellDatabase[i].check==false) check = false;
        }
        if(check)
        {
            switch(ChapterManage.Instance.chapter)
            {
                case Chapter.Spring:
                    ChapterManage.Instance.chapterClear[0] = true;
                    break;
                case Chapter.Summer:
                    ChapterManage.Instance.chapterClear[1] = true;
                    break;
                case Chapter.Autumn:
                    ChapterManage.Instance.chapterClear[2] = true;
                    break;
                case Chapter.Winter:
                    ChapterManage.Instance.chapterClear[3] = true;
                    break;
            }

            clearObject.gameObject.SetActive(true);
            GameManage.Instance.EditState(GameState.PAUSE);
        }
    }
}
