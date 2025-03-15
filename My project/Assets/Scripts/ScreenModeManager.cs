using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenModeManager : MonoBehaviour
{
    public Dropdown ScreenDropdwon;
    public string[] modearray = new string[3] { "Full", "Window", "No full" };

    private void Awake()
    {
        // 현재 ScreenDropdwon에 있는 모든 옵션을 제거 
        ScreenDropdwon.ClearOptions();

        // 새로운 옵션 설정을 위한 OptionData 생성
        List<Dropdown.OptionData> optionList=new List<Dropdown.OptionData>();

        // modearray 배열에 있는 모든 문자열 데이터를 불러와서 optionList에 저장
        foreach(string str in modearray)
        {
            optionList.Add(new Dropdown.OptionData(str));
        }

        // 위에서 생성한 optionList를 dropdown의 옵션 값에 추가
        ScreenDropdwon.AddOptions(optionList);

        // 현재 dropdown에 선택된 옵션을 0번으로 설정
        ScreenDropdwon.value = 0;
    }
    public void Start()
    {
        LoadScreenMode();
        ScreenDropdwon.onValueChanged.AddListener(ScreenModeChaged);

    }

    void ScreenModeChaged(int index)
    {
        switch(index)
        {
            case 0: //전체화면
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height,FullScreenMode.ExclusiveFullScreen);
                break;
            case 1:
                Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
                break;
            case 2:
                Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, FullScreenMode.Windowed);
                
                break;

        }

        SaveScreenMode(index);

        ScreenDropdwon.RefreshShownValue();
    }


    private void SaveScreenMode(int index)
    {
        PlayerPrefs.SetInt("ScreenMode", index);
        PlayerPrefs.Save();
    }

    private void LoadScreenMode()
    {
        int saveindex = PlayerPrefs.GetInt("ScreenMode",0);
        ScreenDropdwon.value = saveindex;
        ScreenModeChaged(saveindex);
    }
}
