using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestUI : MonoBehaviour
{
    [SerializeField]
    Text constellName, constellDir;

    [SerializeField]
    GameObject clear;

    [SerializeField]
    Text seasonName;

    [SerializeField]
    Image skyImage, constellImage;

    [SerializeField]
    Sprite[] skySprites; //계절 밤하늘 스프라이트

    [SerializeField]
    Sprite[] springSprites, summerSprites, autumnSprites, winterSprites; //별자리 스프라이트

    [SerializeField]
    string[] sprConInfo, sumConInfo, autConInfo, winConInfo; //별자리 설명

    public Toggle togglePrefab;
    public GameObject questGroup;
    public CheckConstellation checkConstellation;

    List<Toggle> questList = new List<Toggle>();

    public float gap = 60;

    string season;

    void Start()
    {
        season = GameObject.Find("ChapterManage").GetComponent<ChapterManage>().chapter;
        checkConstellation = GameObject.Find("CheckConstellation").GetComponent<CheckConstellation>();

        for(int i=0;i<sprConInfo.Length;i++)
        {
            sprConInfo[i] = sprConInfo[i].Replace("\\n", "\n");
        }
        for (int i = 0; i < sumConInfo.Length; i++)
        {
            sumConInfo[i] = sumConInfo[i].Replace("\\n", "\n");
        }
        for (int i = 0; i < autConInfo.Length; i++)
        {
            autConInfo[i] = autConInfo[i].Replace("\\n", "\n");
        }
        for (int i = 0; i < winConInfo.Length; i++)
        {
            winConInfo[i] = winConInfo[i].Replace("\\n", "\n");
        }

        QuestInit();
        Tab2Init(season);
    }

    void Update()
    {
        // 퀘스트 클리어 토글에 반영
        for (int i = 0; i < checkConstellation.constell_Database.Length; i++)
        {
            questList[i].isOn = checkConstellation.constell_Database[i].check;
        }
    }

    //퀘스트 생성
    void QuestInit()
    {
        questList.Clear();
        for (int i = 0; i < checkConstellation.constell_Database.Length; i++)
        {
            Toggle quest = Instantiate(togglePrefab);
            quest.transform.SetParent(questGroup.transform,false);
            quest.transform.Find("Label").GetComponent<Text>().text = checkConstellation.constell_Database[i].krName;
            quest.transform.localPosition = new Vector3(0f, 330 - i * gap, 0f);
            quest.transform.localScale = new Vector3(1, 1, 1);
            quest.name = checkConstellation.constell_Database[i].name;

            int index = i;
            string name = checkConstellation.constell_Database[i].krName;
            quest.transform.Find("Label").GetComponent<Button>().onClick.AddListener(() => ConstellBtn(index, name));
            quest.transform.Find("Background").GetComponent<Button>().onClick.AddListener(() => ConstellBtn(index, name));

            quest.isOn = checkConstellation.constell_Database[i].check; 
            quest.interactable = false;

            questList.Add(quest);
        }
    }

    public void ConstellBtn(int index, string name)
    {
        GameObject.Find("Quest").gameObject.SetActive(false);
        GameObject.Find("Tab1Group").transform.Find("PreviousButton").gameObject.SetActive(true);
        GameObject.Find("Tab1Group").transform.Find("ConstellInfo").gameObject.SetActive(true);
        
        constellName.text = name;

        switch (season)
        {
            case "spring":
                constellImage.sprite = springSprites[index];
                constellDir.text = sprConInfo[index];
                break;
            case "summer":
                constellImage.sprite = summerSprites[index];
                constellDir.text = sumConInfo[index];
                break;
            case "autumn":
                constellImage.sprite = autumnSprites[index];
                constellDir.text = autConInfo[index];
                break;
            case "winter":
                constellImage.sprite = winterSprites[index];
                constellDir.text = winConInfo[index];
                break;
        }

        SoundManage.Instance.PlayButtonSound();
    }

    // 전체 별자리 탭
    void Tab2Init(string season)
    {
        switch(season)
        {
            case "spring":
                seasonName.text = "봄철 별자리";
                skyImage.sprite = skySprites[0];
                break;
            case "summer":
                seasonName.text = "여름철 별자리";
                skyImage.sprite = skySprites[1];
                break;
            case "autumn":
                seasonName.text = "가을철 별자리";
                skyImage.sprite = skySprites[2];
                break;
            case "winter":
                seasonName.text = "겨울철 별자리";
                skyImage.sprite = skySprites[3];
                break;
        }
    }
}
