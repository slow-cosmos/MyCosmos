using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterSelect : MonoBehaviour
{
    ChapterManage chapterManage;

    public void Start()
    {
        chapterManage = GameObject.Find("ChapterManage").GetComponent<ChapterManage>();
    }

    public void SpringSelect()
    {
        chapterManage.lst = 11.3f + 24;
        SceneManager.LoadScene("Ingame");
    }

    public void SummerSelect()
    {
        chapterManage.lst = 17.35f + 24;
        SceneManager.LoadScene("Ingame");
    }

    public void AutumnSelect()
    {
        chapterManage.lst = 23.52f + 24;
        SceneManager.LoadScene("Ingame");
    }

    public void WinterSelect()
    {
        chapterManage.lst = 5.44f + 24;
        SceneManager.LoadScene("Ingame");
    }

}
