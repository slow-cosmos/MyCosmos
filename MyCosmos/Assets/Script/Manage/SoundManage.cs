using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManage : MonoBehaviour
{
    public static SoundManage instance;

    public AudioSource audioSource, bgmAudioSource;
    public AudioClip buttonSound, starSound, constellSound;

    public bool onSFX=true, onBGM=true;

    private void Awake()
    {
        if (instance != null) //중복생성 피하기
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
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

    public void BGM()
    {
        if (onBGM)
        {
            bgmAudioSource.volume = 0.3f;
        }
        else
        {
            bgmAudioSource.volume = 0;
        }
    }
}
