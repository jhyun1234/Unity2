using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundmanager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource sfx;
    public AudioSource charsound;
    

    public Slider bgmslider;
    public Slider sfxslider;
    public Slider wholeslider;
    public Slider charslider;
    
 
    public void SetcharVolume(float volume)
    {
        charsound.volume = volume;
        PlayerPrefs.SetFloat("CharVolume", volume);
    }
    public void SetbgmVolume(float volume)
    {
        bgm.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);

    }
    public void SetsfxVolume(float volume)
    {
        sfx.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);

    }
    public void OnsfxVolumePlay(float volume)
    {
        sfx.Play();
    }
    public void OncharVolumePlay(float volume)
    {
        charsound.Play();
    }
    private void Start()
    {
        //bgm.volume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        //sfx.volume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        DontDestroyOnLoad(gameObject);
    }
   

  
}
