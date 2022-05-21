using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingAnimation : MonoBehaviour
{
    [SerializeField]
    Text[] dot;

    void Start()
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        for (int i = 0; i < 3; i++)
        {
            dot[i].color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
