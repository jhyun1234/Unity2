using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exitpanel : MonoBehaviour
{
    public GameObject ExitPanel;
    public static Exitpanel Instance; 


    public void ShowPopup()
    {
        ExitPanel.SetActive(true); // �˾� â Ȱ��ȭ
        
    }

    public void YesButton()
    {
        ExitPanel.SetActive(false);
        SceneManager.LoadScene("Main");

    }
    public void OnClickexit()
    {
       
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#else
        Application.Quit();
#endif
    }
    public void NoButton()
    {
        ExitPanel.SetActive(false); // �ƴϿ� ��ư Ŭ�� �� �˾� â ��Ȱ��ȭ
        
    }
    public void ExitScene()
    {
        ShowPopup(); // ������ â ����
    }
}
