using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChapterSelect : MonoBehaviour
{
    public void SpringSelect()
    {
        ChapterManage.Instance.lst = 11.3f + 24;
        ChapterManage.Instance.chapter = Chapter.Spring;
        LoadingSceneManager.LoadScene("Ingame");

        SoundManage.Instance.PlayButtonSound();
    }

    public void SummerSelect()
    {
        ChapterManage.Instance.lst = 17.35f + 24;
        ChapterManage.Instance.chapter = Chapter.Summer;
        LoadingSceneManager.LoadScene("Ingame");

        SoundManage.Instance.PlayButtonSound();
    }

    public void AutumnSelect()
    {
        ChapterManage.Instance.lst = 23.52f + 24;
        ChapterManage.Instance.chapter = Chapter.Autumn;
        LoadingSceneManager.LoadScene("Ingame");

        SoundManage.Instance.PlayButtonSound();
    }

    public void WinterSelect()
    {
        ChapterManage.Instance.lst = 5.44f + 24;
        ChapterManage.Instance.chapter = Chapter.Winter;
        LoadingSceneManager.LoadScene("Ingame");

        SoundManage.Instance.PlayButtonSound();
    }

}
