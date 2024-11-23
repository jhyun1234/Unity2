using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public static Volume Instance;
    public AudioMixer myMixer;
    public Slider MasterSlider;
    public Slider bgmSlider;
    public Slider sfxSlider;
    public Slider charSlider;

   

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

    private void Start()
    {
        LoadVolumes();
    }
    
   

    private void LoadVolumes() // �ڵ� ����ȭ
    {
        // PlayerPrefs���� ���� ��������, �������� ������ �⺻�� ���
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        charSlider.value = PlayerPrefs.GetFloat("CHARVolume");

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
