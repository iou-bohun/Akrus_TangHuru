using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BackgroundPanelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 객체를 비활성화 합니다.
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
            gameObject.SetActive(false);
    }
}
