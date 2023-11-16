using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System;

public class SellingProgressBar : MonoBehaviour
{
    public TMP_Text levelUIText;
    public TMP_Text levelText;
    public TMP_Text expText;

    [SerializeField] UnityEngine.UI.Slider slider;
    [SerializeField] UnityEngine.UI.Slider expbar;

    float curTime = 30;
    float maxTime = 30;

    float maxExp = 3;
    float curExp = 0;

    public int level = 1;

    private void OnEnable()
    {
        curTime = (float)maxTime;
        expbar.value = (float)curExp / (float)maxExp; // Exp의 값을 0/100으로 시작
    }

    private void Update()
    {
        if (DataManager.Instance.sellingTangHuru >= 1 && B_GameManager.Instance.isBuyReady)
        {
            slider.gameObject.SetActive(true);
            curTime -= Time.deltaTime;
            slider.value = (float)curTime / (float)maxTime;
            ProgerssBarZero();
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
    }

    public void AccelateTime()
    {
        SoundManager.Instance.PlayTapSound();
        curTime -= 3f;
        SoundManager.Instance.PlayTapSound();
    }

    private void ProgerssBarZero()
    {
        if ((float)curTime <= 0)
        {
            curTime = (float)maxTime;
            slider.gameObject.SetActive(false);
            Debug.Log("골듲ㅇ가");
            DataManager.Instance.Deposit(100);
            B_GameManager.Instance.isBuyReady = false;
            B_GameManager.Instance.buySuccess = true;
            foreach (var tangHuru in DataManager.Instance.sellingTanghurus)
            {
                DataManager.Instance.sellingTanghurus.Remove(tangHuru);
                Destroy(tangHuru);
            }
            HandleExp(); // 경험치 및 레벨 관련 기능 호출
        }
    }

    private void HandleExp()
    {
        Debug.Log("경험치 증가");
        curExp += 1;

        expbar.value = (float)curExp / (float)maxExp; // Handle의 값 0/100

        if (expbar.value >= 1)
        {
            expbar.value = expbar.value - 1;
            level++;
            levelUIText.text = level.ToString();
            levelText.text = level.ToString();

            if (level <= 6)
            {
                maxExp += 5;
            }
            else
                maxExp += 6;
        }

        expText.text = curExp.ToString() + "/" + maxExp.ToString();
    }
}
