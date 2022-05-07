using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManage : MonoBehaviour
{
    public Toggle toggle;
    public GameObject QuestGroup;
    public CheckConstellation checkConstellation;

    public float gap = 70;
    //public float questNum = 5;
    public List<string> constellArr;

    void Start()
    {
        checkConstellation = GameObject.Find("CheckConstellation").GetComponent<CheckConstellation>();

        constellArr.Clear();
        for(int i=0;i<checkConstellation.constell_Database.Length;i++)
        {
            constellArr.Add(checkConstellation.constell_Database[i].name);
        }
        Quest();
    }

    //퀘스트 생성
    void Quest()
    {
        for (int i = 0; i < checkConstellation.constell_Database.Length; i++)
        {
            Toggle quest = Instantiate(toggle);
            quest.transform.SetParent(QuestGroup.transform);
            quest.transform.Find("Label").GetComponent<Text>().text = constellArr[i];
            quest.transform.localPosition = new Vector3(0f, 330 - i * gap, 0f);
            quest.transform.localScale = new Vector3(2.5f, 2.5f, 0f);
            quest.GetComponent<RectTransform>().sizeDelta = new Vector2(250f, 20f);

            quest.isOn = false; 
            quest.interactable = false; 
        }
    }

    
}
