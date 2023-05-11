using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManage : MonoBehaviour
{
    private static ChapterManage instance;
    public float lst;
    public string chapter;

    public bool[] chapterClear = new bool[4];

    private void Awake()
    {
        if(instance != null) //중복생성 피하기
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        
        DataManage.Instance.LoadGameData();
    }

    public static ChapterManage Instance
    {
        get
        {
            if(instance==null)
            {
                return null;
            }
            return instance;
        }
    }
}
