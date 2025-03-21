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
        LoadVolumes(); // LoadVolumes()를 먼저 호출

        MasterSlider.onValueChanged.AddListener((float value) => SetVolume("Master", value));
        bgmSlider.onValueChanged.AddListener((float value) => SetVolume("BGM", value));
        sfxSlider.onValueChanged.AddListener((float value) => SetVolume("SFX", value));
        charSlider.onValueChanged.AddListener((float value) => SetVolume("CHAR", value));

    }


    private void LoadVolumes() // 코드 간결화
    {
        // PlayerPrefs에서 값을 가져오되, 존재하지 않으면 기본값 사용
        MasterSlider.value = PlayerPrefs.GetFloat("MasterVolume",0.5f);
        bgmSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
        charSlider.value = PlayerPrefs.GetFloat("CHARVolume", 0.5f);

        SetVolumes();
    }
    public void SetVolume(string parameter, float value)
    {
        // 오디오 믹서에 저장해둔 파라미터 Master,BGM,SFX,CHAR(캐릭터 사운드)
        float volume = Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20;
        myMixer.SetFloat(parameter, volume);// 오디오 믹서는 일반 float 값을 사용하지 않음 dB데시벨은 로그 함수를 기반
        PlayerPrefs.SetFloat(parameter + "Volume",value); // 변경된 볼륨 값을 PlayerPrefs에 저장하여 다음 실행 시에도 유지
        //PlayerPrefs는 작은 크기의 데이터를 저장하는 데 적합
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
