using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   

    
    public void OnClickStart()
    {
        Debug.Log("����");
        SceneManager.LoadScene("Start");
        
    }

    public void OnClickLoad()
    {
        Debug.Log("�ҷ�����");
        SceneManager.LoadScene("Load");
    }

    public void OnClickoption()
    {
        
        Debug.Log("�ɼ�");
        SceneManager.LoadScene("Option");
    }
    public void OnClickAlbum()
    {
        Debug.Log("������");
        SceneManager.LoadScene("Album");
    }
    public void OutScene()
    {
        Debug.Log("������");
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
