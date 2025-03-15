using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class TextController : MonoBehaviour
{
    
    public Text displayText; // 텍스트를 표시할 UI 텍스트 컴포넌트
    public Slider speedSlider; // 텍스트 속도를 조절할 슬라이더
    private string currentText = " "; // 현재까지 표시된 텍스트
    private float typingSpeed; // 텍스트 속도
    public string fullText = "텍스트 속도 표시 테스트 입니다."; // 전체 텍스트 (Inspector에서 설정 가능)
    private Coroutine textCoroutine; // 텍스트 표시 코루틴
    private int currentDialogueIndex = 0; // 현재 대사 인덱스

    private List<string> dialogues = new List<string>
    {
        "안녕하세요! 이것은 대화 시스템입니다.",
        "대사를 출력하는 속도를 조절할 수 있습니다.",
        "스페이스바 또는 마우스 우클릭으로 다음 대사로 넘어갈 수 있습니다.",
        "이제 직접 구현해 보세요!"
    };
    void Start()
    {
        // 슬라이더 초기화
        speedSlider.minValue = 0;
        speedSlider.maxValue = 1;
        speedSlider.value = 0.5f; // "보통"을 기본 값으로 설정
        SetTypingSpeed(speedSlider.value);


        // 슬라이더 값 변경 이벤트 추가
        speedSlider.onValueChanged.AddListener(delegate { OnSpeedChange(); });

        // 텍스트 표시 시작
        StartCoroutine(ShowText());

        textCoroutine = StartCoroutine(ShowText());
    }

    private void StartTyping()
    {
        if (textCoroutine != null)
        {
            StopCoroutine(textCoroutine);
        }
        textCoroutine = StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        displayText.text = "";
        string fullText = dialogues[currentDialogueIndex];
        for (int i = 0; i <= fullText.Length; i++)
        {
            displayText.text = fullText.Substring(0, i);
            
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    // 슬라이더 값 변경 시 호출되는 함수
    public void OnSpeedChange()
    {
        float value = speedSlider.value;
        SetTypingSpeed(value);

       

        if (textCoroutine != null)
        {
            StopCoroutine(textCoroutine);
        }
        textCoroutine = StartCoroutine(ShowText());

    }

    // 슬라이더 값에 따라 텍스트 속도 설정
    void SetTypingSpeed(float value)
    {
        if (value < 0.33f) // 느림
        {
            typingSpeed = 0.2f;
        }
        else if (value < 0.66f) // 보통
        {
            typingSpeed = 0.07f;
        }
        else  // 빠름
        {
            typingSpeed = 0.01f;
        }
    }

    void Update()
    {
        // 🔹 스페이스바 또는 마우스 우클릭 감지
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1))
        {
            NextDialogue();
        }
    }

    void NextDialogue()
    {
        if (currentDialogueIndex < dialogues.Count - 1)
        {
            currentDialogueIndex++;
            StartTyping();
        }
        else
        {
            Debug.Log("📢 대화 종료!");
        }
    }



}
