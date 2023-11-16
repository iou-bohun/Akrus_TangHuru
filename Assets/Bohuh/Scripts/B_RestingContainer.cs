using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class B_RestingContainer : MonoBehaviour
{
    [SerializeField] GameObject strawberryTangHuru;
    [SerializeField] GameObject grapeTang;
    [SerializeField] GameObject orangeTang;
    [SerializeField] GameObject pineappaleTang;
    [SerializeField] GameObject blueberryTang;

    private void Update()
    {
        sUpdate();
        gUpdate();
        oUpdate();
        pUpdate();
        bUpdate ();
    }

    private void sUpdate()
    {
        if (DataManager.Instance.TangCounts[FruitType.Strawberry] >= 1)
        {
            strawberryTangHuru.SetActive(true);
        }
        else
        {
            strawberryTangHuru.SetActive(false);
        }
      }
       private void gUpdate()
        {
            if (DataManager.Instance.TangCounts[FruitType.Grape] >= 1)
            {
            grapeTang.SetActive(true);
            }
            else
            {
            grapeTang.SetActive(false);
            }
        }
    private void oUpdate()
    {
        if (DataManager.Instance.TangCounts[FruitType.orange] >= 1)
        {
            orangeTang.SetActive(true);
        }
        else
        {
            orangeTang.SetActive(false);
        }
    }
    private void pUpdate()
    {
        if (DataManager.Instance.TangCounts[FruitType.pineapple] >= 1)
        {
            pineappaleTang.SetActive(true);
        }
        else
        {
            pineappaleTang.SetActive(false);
        }
    }
    private void bUpdate()
    {
        if (DataManager.Instance.TangCounts[FruitType.blueberry] >= 1)
        {
            blueberryTang.SetActive(true);
        }
        else
        {
            blueberryTang.SetActive(false);
        }
    }
}
