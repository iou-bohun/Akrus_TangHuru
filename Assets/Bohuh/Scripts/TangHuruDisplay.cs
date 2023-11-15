using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TangHuruDisplay : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    public GameObject[] prefabs;
    public GameObject alert;
    int spawnPoint = 0;

    public  void DisplayStrawberryTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.strawberryTangHuru >= 1)
        {
            DataManager.Instance.strawberryTangHuru--;
            DataManager.Instance.sellingStarwberryTangHuru++;
            Debug.Log("소환");
            Instantiate(prefabs[0], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DisplayGrapeTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.grapeTangHuru >= 1)
        {
            DataManager.Instance.grapeTangHuru--;
            DataManager.Instance.sellingGrpaeTangHuru++;
            Debug.Log("소환");
            Instantiate(prefabs[1], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }

    public void DisplayOrangeTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.orangeTangHuru >= 1)
        {
            DataManager.Instance.orangeTangHuru--;
            DataManager.Instance.sellingOrangeTangHuru++;
            Debug.Log("소환");
            Instantiate(prefabs[2], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DispalyPineappleTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.pineappleTangHuru >= 1)
        {
            DataManager.Instance.pineappleTangHuru--;
            DataManager.Instance.sellingPineappleTangHuru++;
            Debug.Log("소환");
            Instantiate(prefabs[3], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DisaplyBlueberryTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.blueberryTangHuru >= 1)
        {
            DataManager.Instance.blueberryTangHuru--;
            DataManager.Instance.sellingBlueberryTangHuru++;
            Debug.Log("소환");
            Instantiate(prefabs[4], spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }

    IEnumerator AlertDelay()
    {
        yield return new WaitForSeconds(3f);
        alert.SetActive(false);
    }

}
