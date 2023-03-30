using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManage : MonoBehaviour
{
    [SerializeField]
    Canvas chapterCanvas;

    [SerializeField]
    Canvas lobbyCanvas;

    public void StartButton()
    {
        chapterCanvas.gameObject.SetActive(true);
        lobbyCanvas.gameObject.SetActive(false);

        SoundManage.instance.PlayButtonSound();
    }

    public void ExitButton()
    {
        DataManage.Instance.SaveGameData();

        Application.Quit();

        SoundManage.instance.PlayButtonSound();
    }

    public void PreviousButton()
    {
        chapterCanvas.gameObject.SetActive(false);
        lobbyCanvas.gameObject.SetActive(true);

        SoundManage.instance.PlayButtonSound();
    }

}
