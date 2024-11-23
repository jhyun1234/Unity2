using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    public Toggle fullScreenButton;

    public void Start()
    {
        // ��ư�� �̺�Ʈ ������ �߰�
        Toggle toggle = fullScreenButton.GetComponent<Toggle>();
        toggle.isOn = Screen.fullScreen;
       
    }

    public void ToggleFullScreen(bool isOn)
    {
        Screen.fullScreen = isOn;
    }


}
