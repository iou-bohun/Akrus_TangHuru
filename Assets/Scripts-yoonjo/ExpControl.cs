using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ExpControl : MonoBehaviour
{
    public TMP_Text levelText;
    public TMP_Text expText;

    [SerializeField] //외부스크립트에서 수정을 하지 못하게 하는 변수(insfactor에서는 접근가능)
    private Slider expbar;

    private float maxExp = 3;  //Exp의 max를 100으로 설정
    private float curExp = 0; //Exp의 초기값을 0으로 설정

    private int level = 1;

    void Start()
    {
        expbar.value = (float)curExp / (float)maxExp; // Exp의 값을 0/100 으로 시작
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"GetKeyDown:{KeyCode.E}");
            curExp += 1;  //E를 누를때마다 Exp가 10씩 증가
        }

        Handle();
    }
    private void Handle()
    {
        expbar.value = (float)curExp / (float)maxExp; //Handle의 값 0/100

        if (expbar.value >= 1)
        {
            expbar.value = expbar.value - 1;
            level++;
            levelText.text = level.ToString();

            if (level <= 6)
            {
                maxExp = maxExp + 5;
            }
            else
                maxExp = maxExp + 6;
        }

        expText.text = curExp.ToString() + "/" + maxExp.ToString();
    }
}
