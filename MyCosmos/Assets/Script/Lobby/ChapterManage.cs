using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManage : MonoBehaviour
{
    public float lst;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
