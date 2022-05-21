using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterSelect : MonoBehaviour
{
    ChapterManage chapterManage;

    private void Start()
    {
        chapterManage = GameObject.Find("ChapterManage").GetComponent<ChapterManage>();
    }

    public void SpringSelect()
    {
        chapterManage.lst = 11.3f + 24;
        chapterManage.chapter = "spring";
        LoadingSceneManager.LoadScene("Ingame");

        SoundManage.instance.PlayButtonSound();
    }

    public void SummerSelect()
    {
        chapterManage.lst = 17.35f + 24;
        chapterManage.chapter = "summer";
        LoadingSceneManager.LoadScene("Ingame");

        SoundManage.instance.PlayButtonSound();
    }

    public void AutumnSelect()
    {
        chapterManage.lst = 23.52f + 24;
        chapterManage.chapter = "autumn";
        LoadingSceneManager.LoadScene("Ingame");

        SoundManage.instance.PlayButtonSound();
    }

    public void WinterSelect()
    {
        chapterManage.lst = 5.44f + 24;
        chapterManage.chapter = "winter";
        LoadingSceneManager.LoadScene("Ingame");

        SoundManage.instance.PlayButtonSound();
    }

}
