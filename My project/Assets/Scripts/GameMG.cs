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
            Debug.Log("���� �ΰ� �̻��� ���ӸŴ����� �����մϴ�.");
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
            Debug.LogError($"�������� �ʴ� ���Դϴ�: {sceneName}");
        }
    }
     
}
