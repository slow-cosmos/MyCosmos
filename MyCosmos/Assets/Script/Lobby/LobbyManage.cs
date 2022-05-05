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
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
