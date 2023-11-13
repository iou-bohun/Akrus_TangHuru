using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingFruit : MonoBehaviour
{
    SpriteRenderer thisSprite;
    [SerializeField] Sprite[] CotingTangHuru;
    public   GameObject processingFruit;

    private void Start()
    {
        thisSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
      if(DataManager.Instance.isFruitAvaliable == true)
        {
            SetPrecessingFruitActive(true);
        }
        else
        {
            SetPrecessingFruitActive(false);
        }
    }


    void SetPrecessingFruitActive(bool isActive)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(isActive);
        }
    }
}
