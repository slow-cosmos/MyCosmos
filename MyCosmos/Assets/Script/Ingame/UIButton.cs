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

    [SerializeField]
    GameObject starSelect;

    public void CloseBtn()
    {
        questCanvas.gameObject.SetActive(false);
        lobbyButton.gameObject.SetActive(true);
        questButton.gameObject.SetActive(true);
        starSelect.gameObject.SetActive(true);

        GameObject.Find("Main Camera").GetComponent<CameraController>().enabled=true;

        SoundManage.instance.PlayButtonSound();
    }

    public void QuestBtn()
    {
        questCanvas.gameObject.SetActive(true);
        lobbyButton.gameObject.SetActive(false);
        questButton.gameObject.SetActive(false);
        starSelect.gameObject.SetActive(false);

        GameObject.Find("Main Camera").GetComponent<CameraController>().enabled=false;

        SoundManage.instance.PlayButtonSound();
    }

    public void LobbyBtn()
    {
        DataManage.Instance.SaveGameData();
        
        SceneManager.LoadScene("Lobby");

        SoundManage.instance.PlayButtonSound();
    }

    public void PreviousBtn()
    {
        questGroup.gameObject.SetActive(true);
        previousButton.gameObject.SetActive(false);
        info.gameObject.SetActive(false);

        SoundManage.instance.PlayButtonSound();
    }

    public void Tab1()
    {
        GameObject.Find("QuestCanvas").transform.Find("Tab1Group").gameObject.SetActive(true);
        GameObject.Find("QuestCanvas").transform.Find("Tab2Group").gameObject.SetActive(false);

        SoundManage.instance.PlayButtonSound();
    }

    public void Tab2()
    {
        GameObject.Find("QuestCanvas").transform.Find("Tab2Group").gameObject.SetActive(true);
        GameObject.Find("QuestCanvas").transform.Find("Tab1Group").gameObject.SetActive(false);

        SoundManage.instance.PlayButtonSound();
    }

}
