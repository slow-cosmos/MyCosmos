using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManage : MonoBehaviour
{
    public static SoundManage instance;

    public AudioSource audioSource;
    public AudioClip buttonSound, starSound, constellSound;

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
        audioSource.volume = 0.3f;
        audioSource.PlayOneShot(buttonSound);
    }

    public void PlayStarSound()
    {
        audioSource.volume = 0.1f;
        audioSource.PlayOneShot(starSound);
    }
    
    public void PlayConstellSound()
    {
        audioSource.volume = 0.3f;
        audioSource.PlayOneShot(constellSound);
    }
}
