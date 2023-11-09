//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class FruitBowl : MonoBehaviour
//{
//    public FruitType fruitType; // 그릇에 들어있는 탕후루 종류
//    private Y_TimebarController timebarController; // 탕후루 제작을 관리하는 스크립트
//    public Button sellButton; // 판매 버튼
//    public Text timeText; // 시간을 표시할 UI Text

//    private void Start()
//    {
//        timebarController = GetComponent<Y_TimebarController>();
//        timebarController.SetFruitType(fruitType);
//        sellButton.onClick.AddListener(SellFruit);
//    }

//    public void SellFruit()
//    {
//        // 판매 시스템 구현
//        Y_TimebarController timebar = GetComponent<Y_TimebarController>();

//        if (timebar.CanAccelerate())
//        {
//            // 판매 가능한 경우
//            // 판매 로직 추가 (예: 골드 추가, 데이터 관리 스크립트 업데이트)
//            DataManager.Instance.Deposit(earnedGold); // earnedGold는 판매로 얻은 골드

//            // 탕후루 재설정
//            timebar.ResetProgressBar();
//        }
//    }
//}

