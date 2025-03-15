using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] GameObject Option_panel;
    public static OptionPanel instance;
  
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 이 오브젝트를 씬 전환 시 파괴하지 않음
        }
        else
        {
            Destroy(gameObject); // 씬에 이미 OptionManager가 있다면 중복 생성 방지
            return;
        }

        Option_panel.SetActive(false); // 시작 시 옵션 패널 비활성화
    }
    void Start()
    {
        Option_panel.SetActive(false);
        
    }

    public void OpPanel()
    {
        if(Option_panel.activeSelf)
        {
            Option_panel.SetActive(false);
          
        }
        else
        {
            Option_panel.SetActive(true);
           
        }
    }
}
