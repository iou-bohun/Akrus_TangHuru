using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class B_RestingContainer : MonoBehaviour
{
    [SerializeField] GameObject strawberryTangHuru;
    private void Update()
    {
        if(DataManager.Instance.strawberryTangHuru >= 1)
        {
            strawberryTangHuru.SetActive(true);
        }
        else
        {
            strawberryTangHuru.SetActive(false);
        }
    }
}
