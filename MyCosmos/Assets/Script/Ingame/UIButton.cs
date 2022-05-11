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

    [SerializeField]
    Image skyImage;

    public void CloseBtn()
    {
        questCanvas.gameObject.SetActive(false);
        lobbyButton.gameObject.SetActive(true);
        questButton.gameObject.SetActive(true);

        GameObject.Find("Main Camera").GetComponent<CameraController>().enabled=true;
    }

    public void QuestBtn()
    {
        questCanvas.gameObject.SetActive(true);
        lobbyButton.gameObject.SetActive(false);
        questButton.gameObject.SetActive(false);

        GameObject.Find("Main Camera").GetComponent<CameraController>().enabled=false;
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


    public void Tab1()
    {
        GameObject.Find("QuestCanvas").transform.Find("Tab1Group").gameObject.SetActive(true);
        GameObject.Find("QuestCanvas").transform.Find("Tab2Group").gameObject.SetActive(false);
    }

    public void Tab2()
    {
        GameObject.Find("QuestCanvas").transform.Find("Tab2Group").gameObject.SetActive(true);
        GameObject.Find("QuestCanvas").transform.Find("Tab1Group").gameObject.SetActive(false);
    }

}
