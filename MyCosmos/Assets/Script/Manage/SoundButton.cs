using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    Image bgmImage;
    Image sfxImage;

    void Start()
    {
        bgmImage = GameObject.Find("BGMButton").GetComponent<Image>();
        sfxImage = GameObject.Find("SFXButton").GetComponent<Image>();

        if(SoundManage.Instance.onSFX) sfxImage.color = new Color32(255,255,255,255);
        else sfxImage.color = new Color32(255,255,255,120);

        if(SoundManage.Instance.onBGM) bgmImage.color = new Color32(255,255,255,255);
        else bgmImage.color = new Color32(255,255,255,120);
    }

    public void ClickSFX()
    {
        SoundManage.Instance.onSFX = SoundManage.Instance.onSFX ? false : true;

        if(SoundManage.Instance.onSFX) sfxImage.color = new Color32(255,255,255,255);
        else sfxImage.color = new Color32(255,255,255,120);

        DataManage.Instance.SaveSoundData();
    }

    public void ClickBGM()
    {
        SoundManage.Instance.onBGM = SoundManage.Instance.onBGM ? false : true;
        GameObject.Find("BGM").GetComponent<BgmManage>().BGM();

        if(SoundManage.Instance.onBGM) bgmImage.color = new Color32(255,255,255,255);
        else bgmImage.color = new Color32(255,255,255,120);

        DataManage.Instance.SaveSoundData();
    }
}
