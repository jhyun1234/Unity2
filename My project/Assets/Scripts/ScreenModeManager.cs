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
        // ���� ScreenDropdwon�� �ִ� ��� �ɼ��� ���� 
        ScreenDropdwon.ClearOptions();

        // ���ο� �ɼ� ������ ���� OptionData ����
        List<Dropdown.OptionData> optionList=new List<Dropdown.OptionData>();

        // modearray �迭�� �ִ� ��� ���ڿ� �����͸� �ҷ��ͼ� optionList�� ����
        foreach(string str in modearray)
        {
            optionList.Add(new Dropdown.OptionData(str));
        }

        // ������ ������ optionList�� dropdown�� �ɼ� ���� �߰�
        ScreenDropdwon.AddOptions(optionList);

        // ���� dropdown�� ���õ� �ɼ��� 0������ ����
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
            case 0: //��üȭ��
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
