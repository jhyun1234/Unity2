using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   

    
    public void OnClickStart()
    {
        Debug.Log("시작");
        SceneManager.LoadScene("Start");
        
    }

    public void OnClickLoad()
    {
        Debug.Log("불러오기");
        SceneManager.LoadScene("Load");
    }

    public void OnClickoption()
    {
        
        Debug.Log("옵션");
        SceneManager.LoadScene("Option");
    }
    public void OnClickAlbum()
    {
        Debug.Log("갤러리");
        SceneManager.LoadScene("Album");
    }
    public void OutScene()
    {
        Debug.Log("나가짐");
        SceneManager.LoadScene("Main");


    }
    public void OnClickexit()
    {
        
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
     if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#else
        Application.Quit();
#endif
    }
}
