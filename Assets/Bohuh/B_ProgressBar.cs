using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class B_ProgressBar : MonoBehaviour
{
    [SerializeField] Slider progressBar;
    [SerializeField] TextMeshProUGUI time;

    // 손질에 걸리는 시간
    private float maxTime = 30;
    // 현재 손질하기 남은 시간
    private float curTime = 30;
    // 손질중인가요
    private bool isPrepping = true;

    private void Start()
    {
        progressBar.value = (float) curTime / (float) maxTime;
    }

    private void Update()
    {
        if(B_GameManager.Instance.isStrawberryReady== true)
        {
            progressBar.gameObject.SetActive(true);
            curTime -= Time.deltaTime;
            time.text = (((int)curTime % 60).ToString() + "s");
            ProgerssBarZero();
            HandleBar();
            spawnTang();
        }
    }

    /// <summary>
    /// 손질에 남은시간이 0인경우
    /// </summary>
    private void ProgerssBarZero()
    {
        if (curTime <= 0.1)
        {
            curTime = 30;
            isPrepping = false;
            progressBar.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 버튼 클릭시 손질시간 감소
    /// </summary>
    public void AccelateTime()
    {
        if (B_GameManager.Instance.isStrawberryReady == false) return;
        curTime -= 3f;
    }

    /// <summary>
    /// 타이머 바 
    /// </summary>
    void HandleBar()
    {
        progressBar.value = (float) curTime / ((float) maxTime);
    }

    void spawnTang()
    {
        if(isPrepping == false)
        {
            FindAnyObjectByType<B_Spawnner>().Spawn();
            isPrepping = true;
        }
    }
}
