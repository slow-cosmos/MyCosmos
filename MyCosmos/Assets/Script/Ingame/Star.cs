using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public bool check;

    void Start()
    {
        Init();
    }

    void Init()
    {
        check = false;
    }

    void CheckStar()
    {
        check = true;
    }

}
