using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Y_TimebarController : MonoBehaviour
{
    public Slider progressBar; // 프로그레스 바 UI 요소
    public Button accelerateButton; // 가속 버튼 UI 요소

    private float totalTime = 30.0f; // 기본 제품 제작 시간 (초)
    private float currentTime; // 현재 진행 시간
    private bool isAccelerated = false; // 가속 상태
    private float lastRealTime; //마지막 실제 시간
    
    public float CurrentTime
    {
        get { return currentTime; }
    }


    private void Start()
    {
        currentTime = totalTime;
        progressBar.maxValue = totalTime;
        progressBar.value = totalTime;
        progressBar.interactable = false; // 가속 버튼을 비활성화

        accelerateButton.onClick.AddListener(AccelerateProgress);

        lastRealTime = Time.realtimeSinceStartup;

        accelerateButton.onClick.AddListener(AccelerateProgress);
    }

    private void Update()
    {
        if (isAccelerated)
        {
            float realTimeNow = Time.realtimeSinceStartup;
            float deltaTime = realTimeNow - lastRealTime;
            lastRealTime = realTimeNow;

             // 가속 버튼을 누를 때 시간을 3초씩 감소
            UpdateProgressBar();
        }
    }

    private void UpdateProgressBar()
    {
        progressBar.value = currentTime;

        if (currentTime <= 0)
        {
            // 제품 완성 처리 또는 다음 단계로 이동
            Debug.Log("계산완료");
            ResetProgressBar();
        }
    }

    private void ResetProgressBar()
    {
        currentTime = totalTime;
        progressBar.value = totalTime;
        isAccelerated = false;
        progressBar.interactable = false;
    }

    public void AccelerateProgress()
    {
        isAccelerated = true;
        progressBar.interactable = true; // 가속 버튼을 비활성화하지 않고 활성화
    }
}

