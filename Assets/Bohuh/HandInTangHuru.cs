using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInTangHuru : MonoBehaviour
{
   public void HandStrawberryTang()
    {
        Debug.Log("ButtonClick");
        if(DataManager.Instance.strawberryTangHuru >= 1)
        {
            DataManager.Instance.strawberryTangHuru--;
            DataManager.Instance.sellingStarwberryTangHuru++;
        }
    }
}
