using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestUI : MonoBehaviour
{
    //계절 밤하늘 스프라이트
    [SerializeField] private Sprite[] skySprites;

    //별자리 스프라이트
    [SerializeField] private Sprite[] springSprites;
    [SerializeField] private Sprite[] summerSprites;
    [SerializeField] private Sprite[] autumnSprites;
    [SerializeField] private Sprite[] winterSprites;

    //별자리 설명
    [SerializeField] private string[] sprConInfo;
    [SerializeField] private string[] sumConInfo;
    [SerializeField] private string[] autConInfo; 
    [SerializeField] private string[] winConInfo;

    [SerializeField] private Toggle togglePrefab;

    [SerializeField] private Text constellName;
    [SerializeField] private Text constellDescription;
    [SerializeField] private Text seasonName;

    [SerializeField] private Image skyImage;
    [SerializeField] private Image zoomSkyImage;
    [SerializeField] private Image constellImage;

    [SerializeField] private GameObject questGroup;
    [SerializeField] private GameObject previousButton;
    [SerializeField] private GameObject constellationInfo;

    [SerializeField] private CheckConstellation checkConstellation;

    [SerializeField] private float gap = 60;
    
    private List<Toggle> questList = new List<Toggle>();

    private void Start()
    {
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

        QuestTabInit();
        MapTabInit();
    }

    private void Update()
    {
        // 퀘스트 클리어 토글에 반영
        for (int i = 0; i < checkConstellation.constellDatabase.Length; i++)
        {
            questList[i].isOn = checkConstellation.constellDatabase[i].check;
        }
    }

    //퀘스트 생성
    private void QuestTabInit()
    {
        questList.Clear();
        for (int i = 0; i < checkConstellation.constellDatabase.Length; i++)
        {
            Toggle quest = Instantiate(togglePrefab);
            quest.transform.SetParent(questGroup.transform,false);
            quest.transform.Find("Name").GetComponent<Text>().text = checkConstellation.constellDatabase[i].krName;
            quest.transform.localPosition = new Vector3(0f, 330 - i * gap, 0f);
            quest.transform.localScale = new Vector3(1, 1, 1);
            quest.name = checkConstellation.constellDatabase[i].name;

            int index = i;
            string name = checkConstellation.constellDatabase[i].krName;
            quest.transform.Find("Name").GetComponent<Button>().onClick.AddListener(() => ConstellBtn(index, name));
            quest.transform.Find("Background").GetComponent<Button>().onClick.AddListener(() => ConstellBtn(index, name));

            quest.isOn = checkConstellation.constellDatabase[i].check; 
            quest.interactable = false;

            questList.Add(quest);
        }
    }

    // 전체 별자리 탭
    private void MapTabInit()
    {
        switch(ChapterManage.Instance.chapter)
        {
            case Chapter.Spring:
                seasonName.text = "봄철 별자리";
                skyImage.sprite = skySprites[0];
                zoomSkyImage.sprite = skySprites[0];
                break;
            case Chapter.Summer:
                seasonName.text = "여름철 별자리";
                skyImage.sprite = skySprites[1];
                zoomSkyImage.sprite = skySprites[0];
                break;
            case Chapter.Autumn:
                seasonName.text = "가을철 별자리";
                skyImage.sprite = skySprites[2];
                zoomSkyImage.sprite = skySprites[0];
                break;
            case Chapter.Winter:
                seasonName.text = "겨울철 별자리";
                skyImage.sprite = skySprites[3];
                zoomSkyImage.sprite = skySprites[0];
                break;
        }
    }

    public void ConstellBtn(int index, string name)
    {
        questGroup.SetActive(false);
        previousButton.gameObject.SetActive(true);
        constellationInfo.gameObject.SetActive(true);
        
        constellName.text = name;

        switch (ChapterManage.Instance.chapter)
        {
            case Chapter.Spring:
                constellImage.sprite = springSprites[index];
                constellDescription.text = sprConInfo[index];
                break;
            case Chapter.Summer:
                constellImage.sprite = summerSprites[index];
                constellDescription.text = sumConInfo[index];
                break;
            case Chapter.Autumn:
                constellImage.sprite = autumnSprites[index];
                constellDescription.text = autConInfo[index];
                break;
            case Chapter.Winter:
                constellImage.sprite = winterSprites[index];
                constellDescription.text = winConInfo[index];
                break;
        }

        SoundManage.Instance.PlayButtonSound();
    }
}
