using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelHandler : MonoBehaviour
{
    void Start()
    {
        DOTween.Init();
        transform.localScale = Vector3.one * 0.1f;
        // 객체 비활성화
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);

        // DOTween 함수를 차례대로 수행
        var seq = DOTween.Sequence();

        // DOScale의 첫 번째 파라미터는 목표 Scale 값, 두 번째는 시간
        seq.Append(transform.DOScale(1.1f, 0.2f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play();
    }

    public void Hide()
    {
        var seq = DOTween.Sequence();

        transform.localScale = Vector3.one * 0.2f;

        seq.Append(transform.DOScale(1.1f, 0.1f));
        seq.Append(transform.DOScale(0.2f, 0.2f));

        // OnComplete는 seq 에 설정한 애니메이션의 플레이가 완료되면
        // {} 안에 있는 코드 수행 => 닫기 애니메이션이 완료된 후 객체 비활성화
        seq.Play().OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }

    void Update()
    {
        
    }
}
