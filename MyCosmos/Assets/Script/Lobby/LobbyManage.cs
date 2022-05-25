using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManage : MonoBehaviour
{
    [SerializeField]
    Canvas chapterCanvas;

    [SerializeField]
    Canvas lobbyCanvas;

    [SerializeField]
    GameObject background;

    public void StartButton()
    {
        chapterCanvas.gameObject.SetActive(true);
        lobbyCanvas.gameObject.SetActive(false);

        float initScale = background.transform.localScale.x;

        background.transform.localPosition = new Vector3(-0.08f, 1.01f, 0);
        background.transform.localScale = new Vector3(initScale*1.33f, initScale * 1.33f, initScale * 1.33f);

        SoundManage.instance.PlayButtonSound();
    }

    public void ExitButton()
    {
        Application.Quit();

        SoundManage.instance.PlayButtonSound();
    }

    public void PreviousButton()
    {
        chapterCanvas.gameObject.SetActive(false);
        lobbyCanvas.gameObject.SetActive(true);

        float initScale = background.transform.localScale.x;

        background.transform.localPosition = new Vector3(-0.08f, 1.98f, 0);
        background.transform.localScale = new Vector3(initScale / 1.33f, initScale / 1.33f, initScale / 1.33f);

        SoundManage.instance.PlayButtonSound();
    }

}
