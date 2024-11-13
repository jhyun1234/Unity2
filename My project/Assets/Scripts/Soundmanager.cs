using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource sfx;
    
    public void SetbgmVolume(float volume)
    {
        bgm.volume= volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
        //PlayerPrefs.Save();
    }
    public void SetsfxVolume(float volume)
    {
        sfx.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }
    public void OnsfxVolumePlay(float volume)
    {
        sfx.Play();
    }

    private void Start()
    {
        bgm.volume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        bgm.volume = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
    }
}
