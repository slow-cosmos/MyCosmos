using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheck : MonoBehaviour
{
    public GameObject[] clearText;

    void Start()
    {
        for (int i = 0; i < ChapterManage.Instance.chapterClear.Length; i++)
        {
            if (ChapterManage.Instance.chapterClear[i] == true)
                clearText[i].gameObject.SetActive(true);
           }

    }

}
