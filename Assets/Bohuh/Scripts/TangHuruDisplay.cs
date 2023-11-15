using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TangHuruDisplay : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    public GameObject prefab;
    public GameObject alert;
    int spawnPoint = 0;

    public  void DisplayStrawberryTangHuru()
    {
        if (DataManager.Instance.sellingTangHuru >= 6)
        {
            Debug.Log("판매대가 모자랍니다");
            alert.SetActive(true);
            StartCoroutine("AlertDelay");
            return;
        }
        if (DataManager.Instance.strawberryTangHuru >= 1)
        {
            SoundManager.Instance.PlayTapSound();
            DataManager.Instance.strawberryTangHuru--;
            DataManager.Instance.sellingStarwberryTangHuru++;
            Debug.Log("소환");
            Instantiate(prefab, spawnPoints[DataManager.Instance.sellingTangHuru].position, spawnPoints[DataManager.Instance.sellingTangHuru].rotation);
            DataManager.Instance.sellingTangHuru++;
        }
    }
    public void DisplayGrapeTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
        DataManager.Instance.grapeTangHuru++;
    }
    public void DisplayOrangeTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
    }
    public void DispalyPineappleTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
    }
    public void DisaplyBlueberryTangHuru()
    {
        SoundManager.Instance.PlayTapSound();
    }

    public void DisplayTang(int value)
    {

    }

    IEnumerator AlertDelay()
    {
        yield return new WaitForSeconds(3f);
        alert.SetActive(false);
    }
}
