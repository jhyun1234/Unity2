using UnityEngine;
using UnityEngine.Audio;
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

    
    public void Start()
    {
        LoadVolumes(); // LoadVolumes()�� ���� ȣ��

        MasterSlider.onValueChanged.AddListener((float value) => SetVolume("Master", value));
        bgmSlider.onValueChanged.AddListener((float value) => SetVolume("BGM", value));
        sfxSlider.onValueChanged.AddListener((float value) => SetVolume("SFX", value));
        charSlider.onValueChanged.AddListener((float value) => SetVolume("CHAR", value));

    }


    private void LoadVolumes() // �ڵ� ����ȭ
    {
        // PlayerPrefs���� ���� ��������, �������� ������ �⺻�� ���
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume",0.5f);
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        charSlider.value = PlayerPrefs.GetFloat("CHARVolume", 0.5f);

        SetVolumes();
    }
    public void SetVolume(string parameter, float value)
    {
        // ����� �ͼ��� �����ص� �Ķ���� Master,BGM,SFX,CHAR(ĳ���� ����)
        float volume = Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20;
        myMixer.SetFloat(parameter, volume);// ����� �ͼ��� �Ϲ� float ���� ������� ���� dB���ú��� �α� �Լ��� ���
        PlayerPrefs.SetFloat(parameter + "Volume",value); // ����� ���� ���� PlayerPrefs�� �����Ͽ� ���� ���� �ÿ��� ����
        //PlayerPrefs�� ���� ũ���� �����͸� �����ϴ� �� ����
    }
    public void SetVolumes()
    {

        SetVolume("Master", MasterSlider.value);
        SetVolume("BGM", bgmSlider.value);
        SetVolume("SFX", sfxSlider.value);
        SetVolume("CHAR", charSlider.value);
        PlayerPrefs.Save();
    }
    

   

}
