using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    // 게임 데이터 및 상태 변수 선언 (골드, 탕후루 개수 등)
    public static int currentGold = 0; // currentGold를 static으로 변경

    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataManager>();
            }
            return instance;
        }
    }

    // 골드 관리, 탕후루 개수 업데이트 등을 위한 함수들
    public void Deposit(int amount)
    {
        currentGold += amount;
    }
}


