//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Y_TimebarController : MonoBehaviour
//{
//    public Slider progressBar; // 프로그레스 바 UI 요소
//    public Button accelerateButton; // 가속 버튼 UI 요소
//    public Text timeText; // 시간을 표시할 UI Text

//    // 각 탕후루 종류별 계산 시간 및 쿨타임
//    private Dictionary<FruitType, float> preparationTimes = new Dictionary<FruitType, float>
//    {
//        { FruitType.StrawberryTang, 21.0f },
//        { FruitType.GrapeTang, 21.0f },
//        { FruitType.OrangeTang, 30.0f },
//        { FruitType.PineappleTang, 30.0f },
//        { FruitType.BlueberryTang, 30.0f }
//    };

//    private float currentTime; // 현재 진행 시간
//    private bool isAccelerated = false; // 가속 상태
//    private float lastRealTime; // 마지막 실제 시간

//    public float CurrentTime
//    {
//        get { return currentTime; }
//    }

//    private void Start()
//    {
//        // 초기 계산 시간 설정
//        currentFruitType = FruitType.StrawberryTang; // 처음에 딸기탕후루로 시작
//        currentTime = preparationTimes[currentFruitType];
//        progressBar.maxValue = preparationTimes[currentFruitType];
//        progressBar.value = preparationTimes[currentFruitType];
//        progressBar.interactable = false;

//        accelerateButton.onClick.AddListener(AccelerateProgress);

//        lastRealTime = Time.realtimeSinceStartup;
//    }

//    private void Update()
//    {
//        if (isAccelerated)
//        {
//            float realTimeNow = Time.realtimeSinceStartup;
//            float deltaTime = realTimeNow - lastRealTime;
//            lastRealTime = realTimeNow;

//            currentTime -= deltaTime;
//            UpdateProgressBar();
//        }
//    }

//    private void UpdateProgressBar()
//    {
//        progressBar.value = currentTime;
//        timeText.text = Mathf.FloorToInt(currentTime) + "s";

//        if (currentTime <= 0)
//        {
//            Debug.Log("탕후루 제작 완료");
//            ResetProgressBar();
//        }
//    }

//    private void ResetProgressBar()
//    {
//        currentTime = preparationTimes[currentFruitType];
//        progressBar.value = preparationTimes[currentFruitType];
//        isAccelerated = false;
//        progressBar.interactable = false;
//    }

//    private FruitType currentFruitType; // 현재 선택된 탕후루 종류

//    public void SetFruitType(FruitType fruitType)
//    {
//        currentFruitType = fruitType;
//        currentTime = preparationTimes[currentFruitType];
//        progressBar.maxValue = preparationTimes[currentFruitType];
//        progressBar.value = preparationTimes[currentFruitType];
//    }

//    public void AccelerateProgress()
//    {
//        // 가속 버튼을 누를 때 쿨타임을 확인
//        if (CanAccelerate())
//        {
//            isAccelerated = true;
//            progressBar.interactable = true;
//        }
//    }

//    public bool CanAccelerate()
//    {
//        // 쿨타임이 0 이하인 경우 가속 가능
//        return preparationTimes[currentFruitType] <= 0;
//    }
//}
