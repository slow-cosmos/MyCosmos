using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Canvas questCanvas;

    [SerializeField] private Button previousButton;
    [SerializeField] private Button lobbyButton;
    [SerializeField] private Button questButton;

    [SerializeField] private GameObject starSelect;
    [SerializeField] private GameObject questGroup;
    [SerializeField] private GameObject questTab;
    [SerializeField] private GameObject mapTab;
    [SerializeField] private GameObject info;

    public void CloseButton()
    {
        questCanvas.gameObject.SetActive(false);
        lobbyButton.gameObject.SetActive(true);
        questButton.gameObject.SetActive(true);
        starSelect.gameObject.SetActive(true);

        cameraController.IsEnabled = true;

        SoundManage.Instance.PlayButtonSound();
    }

    public void QuestButton()
    {
        questCanvas.gameObject.SetActive(true);
        lobbyButton.gameObject.SetActive(false);
        questButton.gameObject.SetActive(false);
        starSelect.gameObject.SetActive(false);

        cameraController.IsEnabled = false;

        SoundManage.Instance.PlayButtonSound();
    }

    public void LobbyButton()
    {
        DataManage.Instance.SaveGameData();
        
        SceneManager.LoadScene("Lobby");

        SoundManage.Instance.PlayButtonSound();
    }

    public void PreviousButton()
    {
        questGroup.gameObject.SetActive(true);
        previousButton.gameObject.SetActive(false);
        info.gameObject.SetActive(false);

        SoundManage.Instance.PlayButtonSound();
    }

    public void QuestTabButton()
    {
        questTab.SetActive(true);
        mapTab.SetActive(false);

        SoundManage.Instance.PlayButtonSound();
    }

    public void MapTabButton()
    {
        questTab.SetActive(false);
        mapTab.SetActive(true);

        SoundManage.Instance.PlayButtonSound();
    }

}
