using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManage : MonoBehaviour
{
    public Toggle togglePrefab;
    public GameObject questGroup;
    public CheckConstellation checkConstellation;

    public float gap = 70;
    //public float questNum = 5;

    void Start()
    {
        checkConstellation = GameObject.Find("CheckConstellation").GetComponent<CheckConstellation>();

        QuestInit();
    }

    //퀘스트 생성
    void QuestInit()
    {
        for (int i = 0; i < checkConstellation.constell_Database.Length; i++)
        {
            Toggle quest = Instantiate(togglePrefab);
            quest.transform.SetParent(questGroup.transform,false);
            quest.transform.Find("Label").GetComponent<Text>().text = checkConstellation.constell_Database[i].krName;
            quest.transform.localPosition = new Vector3(0f, 330 - i * gap, 0f);
            quest.transform.localScale = new Vector3(1, 1, 1);
            quest.name = checkConstellation.constell_Database[i].name;
            //quest.GetComponent<RectTransform>().sizeDelta = new Vector2(250f, 20f);

            quest.isOn = false; 
            quest.interactable = false; 
        }
    }

    
}
