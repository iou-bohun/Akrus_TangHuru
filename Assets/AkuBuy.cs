using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkuBuy : MonoBehaviour
{
    [SerializeField] float speed = 100;
    Vector2 originalPosition;

    private void Awake()
    {
        originalPosition = this.transform.localPosition;
    }

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        AkuBuyProcess();
        MoveToOrigin();
    }

    void AkuBuyProcess()
    {
        //야쿠루가 구매하는 장소에 도착했을때 
        if(transform.localPosition.y > -1.5)
        {
            //이동 멈추기 
            speed = 0;
            //애니메이션 전환
        }

    }

    void MoveToOrigin()
    {
        // 야쿠루가 구매를 다 하고 이동했을때 
        //transform.localPosition = originalPosition;
       // speed = 100;
    }
}
