using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public bool onSFX, onBGM;

    void Start()
    {
        onSFX = SoundManage.instance.onSFX;
        onBGM = SoundManage.instance.onBGM;
    }

    public void ClickSFX()
    {
        onSFX = onSFX ? false : true;
    }

    public void ClickBGM()
    {
        onBGM = onBGM ? false : true;
        SoundManage.instance.BGM();
    }
}
