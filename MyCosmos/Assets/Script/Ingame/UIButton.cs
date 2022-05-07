using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    [SerializeField]
    Canvas questCanvas;

    [SerializeField]
    Button previousButton, lobbyButton, questButton;

    [SerializeField]
    GameObject questGroup;

    [SerializeField]
    GameObject info;

    public void CloseBtn()
    {
        questCanvas.gameObject.SetActive(false);
        lobbyButton.gameObject.SetActive(true);
        questButton.gameObject.SetActive(true);
    }

    public void QuestBtn()
    {
        questCanvas.gameObject.SetActive(true);
        lobbyButton.gameObject.SetActive(false);
        questButton.gameObject.SetActive(false);
    }

    public void LobbyBtn()
    {
        SceneManager.LoadScene("Lobby");
    }

    public void PreviousBtn()
    {
        questGroup.gameObject.SetActive(true);
        previousButton.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
    }

    public void ConstellBtn()
    {
        GameObject.Find("Quest").gameObject.SetActive(false);
        GameObject.Find("QuestCanvas").transform.Find("PreviousButton").gameObject.SetActive(true);
        GameObject.Find("QuestCanvas").transform.Find("ConstellInfo").gameObject.SetActive(true);
    }

}
