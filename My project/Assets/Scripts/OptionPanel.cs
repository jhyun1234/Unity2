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
            DontDestroyOnLoad(gameObject); // �� ������Ʈ�� �� ��ȯ �� �ı����� ����
        }
        else
        {
            Destroy(gameObject); // ���� �̹� OptionManager�� �ִٸ� �ߺ� ���� ����
            return;
        }

        Option_panel.SetActive(false); // ���� �� �ɼ� �г� ��Ȱ��ȭ
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
