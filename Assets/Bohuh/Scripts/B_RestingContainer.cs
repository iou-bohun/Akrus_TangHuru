using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class B_RestingContainer : MonoBehaviour
{
    [SerializeField] GameObject strawberryTangHuru;
    [SerializeField] GameObject grapeTangHuru;
    [SerializeField] GameObject orangeTangHuru;
    [SerializeField] GameObject pineappleTangHuru;
    [SerializeField] GameObject blueberryTangHuru;

    private void Update()
    {
        UpdateStrawberryTangHuru();
        UpdateGrapeTangHuru();
        UpdateOrangeTangHuru();
        UpdatePineappleTangHuru();
        UpdateBlueberryTangHuru();
    }

    private void UpdateStrawberryTangHuru()
    {
        if (DataManager.Instance.strawberryTangHuru >= 1)
        {
            strawberryTangHuru.SetActive(true);
        }
        else
        {
            strawberryTangHuru.SetActive(false);
        }
    }
    private void UpdateGrapeTangHuru()
    {
        if (DataManager.Instance.grapeTangHuru >= 1)
        {
            grapeTangHuru.SetActive(true);
        }
        else
        {
            grapeTangHuru.SetActive(false);
        }
    }
    private void UpdateOrangeTangHuru()
    {
        if (DataManager.Instance.orangeTangHuru >= 1)
        {
            orangeTangHuru.SetActive(true);
        }
        else
        {
            orangeTangHuru.SetActive(false);
        }
    }
    private void UpdatePineappleTangHuru()
    {
        if (DataManager.Instance.pineappleTangHuru >= 1)
        {
            pineappleTangHuru.SetActive(true);
        }
        else
        {
            pineappleTangHuru.SetActive(false);
        }
    }
    private void UpdateBlueberryTangHuru()
    {
        if (DataManager.Instance.blueberryTangHuru >= 1)
        {
            blueberryTangHuru.SetActive(true);
        }
        else
        {
            blueberryTangHuru.SetActive(false);
        }
    }
}
