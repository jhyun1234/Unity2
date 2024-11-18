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
    public void SetMaster()  // �ڵ� ����ȭ ��
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
    private void LoadVolumes() // �ڵ� ����ȭ
    {
        // PlayerPrefs���� ���� ��������, �������� ������ �⺻�� ���
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
        // ����� �ͼ��� �����ص� �Ķ���� Master,BGM,SFX,CHAR(ĳ���� ����)
        myMixer.SetFloat(parameter, Mathf.Log10(value) * 20); // ����� �ͼ��� �Ϲ� float ���� ������� ���� dB���ú��� �α� �Լ��� ���
        PlayerPrefs.SetFloat(parameter + "Volume",value); // ����� ���� ���� PlayerPrefs�� �����Ͽ� ���� ���� �ÿ��� ����
        //PlayerPrefs�� ���� ũ���� �����͸� �����ϴ� �� ����
    }
}
