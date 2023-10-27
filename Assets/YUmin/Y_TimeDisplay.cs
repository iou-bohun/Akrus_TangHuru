using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Y_TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI timeText;   //text ui 요소
    public Y_TimebarController progressBarController;


    void Update()
    {
        //현재 시간을 텍스트로 표시
        float currentTime = progressBarController.CurrentTime;
        int timeInSeconds = Mathf.FloorToInt(currentTime);  //초 단위로 변환
        timeText.text = timeInSeconds + "s";
    }
}
