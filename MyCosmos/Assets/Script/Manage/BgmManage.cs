using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManage : MonoBehaviour
{
    void Start()
    {
        BGM();
    }

    public void BGM()
    {
        Debug.Log("BGM:"+SoundManage.Instance.onBGM);
        if (SoundManage.Instance.onBGM)
        {
            GetComponent<AudioSource>().volume = 0.3f;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }
}
