using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManage : MonoBehaviour
{
    public float lst;
    public string chapter;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
