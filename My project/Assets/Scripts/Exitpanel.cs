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
        ExitPanel.SetActive(true); // 팝업 창 활성화
        
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
        ExitPanel.SetActive(false); // 아니오 버튼 클릭 시 팝업 창 비활성화
        
    }
    public void ExitScene()
    {
        ShowPopup(); // 나가기 창 띄우기
    }
}
