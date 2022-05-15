using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck : MonoBehaviour
{
    ChapterManage chapterManage;
    public GameObject[] clearText;

    void Start()
    {
        chapterManage = GameObject.Find("ChapterManage").GetComponent<ChapterManage>();
        for (int i = 0; i < chapterManage.chapterClear.Length; i++)
        {
            if (chapterManage.chapterClear[i] == true)
                clearText[i].gameObject.SetActive(true);
           }

    }

}
