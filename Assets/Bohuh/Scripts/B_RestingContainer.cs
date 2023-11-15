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
        if (DataManager.Instance.strawberryTangHuru >= 1)
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
            if (DataManager.Instance.grapeTangHuru >= 1)
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
        if (DataManager.Instance.orangeTangHuru >= 1)
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
        if (DataManager.Instance.pineappleTangHuru >= 1)
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
        if (DataManager.Instance.blueberryTangHuru >= 1)
        {
            blueberryTang.SetActive(true);
        }
        else
        {
            blueberryTang.SetActive(false);
        }
    }
}
