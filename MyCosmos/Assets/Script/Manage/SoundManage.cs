using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManage : MonoBehaviour
{
    private static SoundManage instance;

    public AudioSource audioSource;
    public AudioClip buttonSound, starSound, constellSound;

    public bool onSFX, onBGM;

    private void Awake()
    {
        if (instance != null) //중복생성 피하기
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        DataManage.Instance.LoadSoundData();
    }

    public static SoundManage Instance
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

    public void PlayButtonSound()
    {
        audioSource.volume = onSFX ? 0.3f : 0;
        audioSource.PlayOneShot(buttonSound);
    }

    public void PlayStarSound()
    {
        audioSource.volume = onSFX ? 0.1f : 0;
        audioSource.PlayOneShot(starSound);
    }
    
    public void PlayConstellSound()
    {
        audioSource.volume = onSFX ? 0.3f : 0;
        audioSource.PlayOneShot(constellSound);
    }
}
