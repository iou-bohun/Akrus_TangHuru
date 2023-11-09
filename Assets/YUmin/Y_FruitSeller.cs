//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class FruitSeller : MonoBehaviour
//{
//    public List<FruitBowl> fruitBowls; // 모든 그릇을 관리
//    public DataManager dataManager; // 데이터 관리 스크립트
//    public Text earnedGoldText; // 판매로 얻은 골드 표시를 위한 UI Text

//    private void Update()
//    {
//        // 판매로 얻은 골드를 UI에 표시
//        int earnedGold = CalculateEarnedGold();
//        earnedGoldText.text = "Earned Gold: " + earnedGold;
//    }

//    private int CalculateEarnedGold()
//    {
//        int earnedGold = 0;

//        foreach (FruitBowl bowl in fruitBowls)
//        {
//            Y_TimebarController timebar = bowl.GetComponent<Y_TimebarController>();

//            if (timebar.CanAccelerate())
//            {
//                // 판매 가능한 경우, 골드 계산 추가 (예: 각 탕후루 별 가격 계산)
//                int price = CalculatePrice(bowl.fruitType);
//                earnedGold += price;
//            }
//        }

//        return earnedGold;
//    }

//    private int CalculatePrice(FruitType fruitType)
//    {
//        // 각 탕후루 별 가격 계산 (예: 딸기탕후루는 10골드, 청포도탕후루는 15골드 등)
//        switch (fruitType)
//        {
//            case FruitType.StrawberryTang:
//                return 20;
//            case FruitType.GrapeTang:
//                return 20;
//            // 다른 탕후루의 가격 계산 추가
//            default:
//                return 5; // 기본 가격
//        }
//    }
//}
