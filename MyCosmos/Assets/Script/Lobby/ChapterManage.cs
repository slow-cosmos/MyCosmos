using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManage : MonoBehaviour
{
    public static ChapterManage Instance;
    public float lst;
    public string chapter;

    public bool[] chapterClear;

    private void Awake()
    {
        if(Instance != null) //중복생성 피하기
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
