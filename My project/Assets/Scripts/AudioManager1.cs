using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager1 : MonoBehaviour
{
    public static AudioManager1 Instance;
    public AudioSource bgmSource;
    public AudioSource sfxSource;
    public AudioSource charSource;


    public AudioClip bgm;
    public AudioClip sfx;
    public AudioClip charv;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayBGM()
    {
        bgmSource.clip = bgm;
        bgmSource.Play();
    }
    
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    public void PlayCHAR(AudioClip clip)
    {
        charSource.PlayOneShot(clip);
    }


}
