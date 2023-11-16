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

    [SerializeField] UnityEngine.UI.Slider slider;

    float curTime = 30;
    float maxTime = 30;

    private void OnEnable()
    {
        curTime = (float)maxTime;
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
            Debug.Log("°ñµåÁõ°¡");
            DataManager.Instance.Deposit(100);
            DataManager.Instance.sellingTangHuru--;
            B_GameManager.Instance.isBuyReady = false;
            B_GameManager.Instance.buySuccess = true;
            foreach (var tangHuru in DataManager.Instance.sellingTanghurus)
            {
                GameObject obf = DataManager.Instance.sellingTanghurus.Pop();
                Destroy(obf);
            }
        }
    }
}
