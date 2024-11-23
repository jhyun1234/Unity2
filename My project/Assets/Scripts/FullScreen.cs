using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    public Toggle fullScreenButton;

    public void Start()
    {
        // 버튼에 이벤트 리스너 추가
        Toggle toggle = fullScreenButton.GetComponent<Toggle>();
        toggle.isOn = Screen.fullScreen;
       
    }

    public void ToggleFullScreen(bool isOn)
    {
        Screen.fullScreen = isOn;
    }


}
