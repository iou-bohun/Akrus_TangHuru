using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInTangHuru : MonoBehaviour
{
   public void HandStrawberryTang()
    {
        if(DataManager.Instance.strawberryTangHuru >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.strawberryTangHuru--;
            DataManager.Instance.sellingStarwberryTangHuru++;

        }
    }
}
