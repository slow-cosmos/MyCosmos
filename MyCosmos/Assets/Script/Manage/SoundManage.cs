using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManage : MonoBehaviour
{
    public static SoundManage Instance;

    public AudioSource audioSource, bgmAudioSource;
    public AudioClip buttonSound, starSound, constellSound;

    public bool onSFX, onBGM;

    private void Awake()
    {
        if (Instance != null) //중복생성 피하기
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        DataManage.Instance.LoadSoundData();
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
