using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioMixer myMixer;
    public Slider MasterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Slider charSlider;
    
    private void Start() 
    {
        DontDestroyOnLoad(gameObject); 
        LoadVolumes();
        /*
        if (PlayerPrefs.HasKey("MasterVolume")&& PlayerPrefs.HasKey("bgmVolume") && PlayerPrefs.HasKey("sfxVolume") && PlayerPrefs.HasKey("charVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetBGMVolume();
            SetSFXVolume();
            SetCharVolume();
            SetMaster();
        }*/
    }
    /*
    public void SetMaster()  // 코드 간결화 전
    {
        float vloume = MasterSlider.value;
        myMixer.SetFloat("Master", Mathf.Log10(vloume) * 20);
        PlayerPrefs.SetFloat("MasterVolume", vloume);
        myMixer.SetFloat("BGM", Mathf.Log10(vloume) * 20);
        PlayerPrefs.SetFloat("bgmVolume", vloume);
        myMixer.SetFloat("SFX", Mathf.Log10(vloume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", vloume);
        myMixer.SetFloat("CHAR", Mathf.Log10(vloume) * 20);
        PlayerPrefs.SetFloat("charVolume", vloume);
    }
    public void SetBGMVolume()
    {
        float vloume = bgmSlider.value;
        myMixer.SetFloat("BGM", Mathf.Log10(vloume)*20);
        PlayerPrefs.SetFloat("bgmVolume", vloume);
    }


    public void SetSFXVolume()
    {
        float vloume = sfxSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(vloume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", vloume);
    }

    public void SetCharVolume()
    {
        float vloume = charSlider.value;
        myMixer.SetFloat("CHAR", Mathf.Log10(vloume) * 20);
        PlayerPrefs.SetFloat("charVolume", vloume);
    }
    private void LoadVolume()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume");
        SetBGMVolume();
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetSFXVolume();
        charSlider.value = PlayerPrefs.GetFloat("charVolume");
        SetCharVolume();
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        SetMaster();
    }
    */
    private void LoadVolumes() // 코드 간결화
    {
        // PlayerPrefs에서 값을 가져오되, 존재하지 않으면 기본값 사용
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        charSlider.value = PlayerPrefs.GetFloat("CharVolume");

        SetVolumes();
    }
    public void SetVolumes()
    {

        SetVolume("Master", MasterSlider.value);
        SetVolume("BGM", bgmSlider.value);
        SetVolume("SFX", sfxSlider.value);
        SetVolume("CHAR", charSlider.value);
    }
    
    public void SetVolume(string parameter, float value)
    {
        // 오디오 믹서에 저장해둔 파라미터 Master,BGM,SFX,CHAR(캐릭터 사운드)
        myMixer.SetFloat(parameter, Mathf.Log10(value) * 20); // 오디오 믹서는 일반 float 값을 사용하지 않음 dB데시벨은 로그 함수를 기반
        PlayerPrefs.SetFloat(parameter + "Volume",value); // 변경된 볼륨 값을 PlayerPrefs에 저장하여 다음 실행 시에도 유지
        //PlayerPrefs는 작은 크기의 데이터를 저장하는 데 적합
    }
}
