using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class GameMG : MonoBehaviour
{
    public static GameMG instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("씬에 두개 이상의 게임매니저가 존재합니다.");
            Destroy(gameObject);
        }
    }


    public void LoadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError($"존재하지 않는 씬입니다: {sceneName}");
        }
    }
     
}
