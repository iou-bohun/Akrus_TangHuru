using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TangHuruDisplay : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    public GameObject[] prefab;
    public GameObject alert;
    int spawnPoint = 0;

    public  void DisplayStrawberryTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 3)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.TangCounts[FruitType.Strawberry] >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.TangCounts[FruitType.Strawberry]--;
            DataManager.Instance.sellingStarwberryTangHuru++;
            GameObject sellTang =  Instantiate(prefab[0], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTanghurus.Push(sellTang);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DisplayGrapeTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 3)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.TangCounts[FruitType.Grape] >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.TangCounts[FruitType.Grape]--;
            DataManager.Instance.sellingGrapeTangHuru++;
            Debug.Log("소환");
            GameObject sellTang = Instantiate(prefab[1], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTanghurus.Push(sellTang);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DisplayOrangeTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 3)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.TangCounts[FruitType.orange] >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.TangCounts[FruitType.orange]--;
            DataManager.Instance.sellingOrangeTangHuru++;
            Debug.Log("소환");
            GameObject sellTang = Instantiate(prefab[2], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTanghurus.Push(sellTang);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DispalyPineappleTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 3)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.TangCounts[FruitType.pineapple] >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.TangCounts[FruitType.pineapple]--;
            DataManager.Instance.sellingPineappleTangHuru++;
            Debug.Log("소환");
            GameObject sellTang = Instantiate(prefab[3], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTanghurus.Push(sellTang);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DisaplyBlueberryTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 3)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.TangCounts[FruitType.blueberry] >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.TangCounts[FruitType.blueberry]--;
            DataManager.Instance.SellingBlueberryTangHuru++;
            GameObject sellTang = Instantiate(prefab[4], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTanghurus.Push(sellTang);
            DataManager.Instance.sellingTangHuru++;
        }
    }

    IEnumerator AlertDelay()
    {
        yield return new WaitForSeconds(3f);
        alert.SetActive(false);
    }
}
