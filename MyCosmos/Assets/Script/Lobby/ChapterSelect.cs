using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterSelect : MonoBehaviour
{
    ChapterManage chapterManage;
    public GameObject[] clearText;

    private void Start()
    {
        chapterManage = GameObject.Find("ChapterManage").GetComponent<ChapterManage>();

        /*for(int i=0;i<chapterManage.chapterClear.Length;i++)
        {
            if (chapterManage.chapterClear[i] == true)
                clearText[i].gameObject.SetActive(true);
        }*/
    }

    public void SpringSelect()
    {
        chapterManage.lst = 11.3f + 24;
        chapterManage.chapter = "spring";
        LoadingSceneManager.LoadScene("Ingame");
    }

    public void SummerSelect()
    {
        chapterManage.lst = 17.35f + 24;
        chapterManage.chapter = "summer";
        LoadingSceneManager.LoadScene("Ingame");
    }

    public void AutumnSelect()
    {
        chapterManage.lst = 23.52f + 24;
        chapterManage.chapter = "autumn";
        LoadingSceneManager.LoadScene("Ingame");
    }

    public void WinterSelect()
    {
        chapterManage.lst = 5.44f + 24;
        chapterManage.chapter = "winter";
        LoadingSceneManager.LoadScene("Ingame");
    }

}
