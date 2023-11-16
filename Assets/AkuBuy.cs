using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkuBuy : MonoBehaviour
{
    [SerializeField] float speed = 100;
    Vector2 originalPosition;
    Animator anim;

    private void Awake()
    {
        originalPosition = this.transform.localPosition;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        AkuBuyProcess();
        MoveToOrigin();
        AkuBuySuccess();
    }

    void AkuBuyProcess()
    {
        if (transform.position.y<0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        //야쿠루가 구매하는 장소에 도착했을때 
        if (transform.localPosition.y > 0)
        {
            //이동 멈추기 
            speed = 0;
            //애니메이션 전환
            anim.SetBool("buying", true);
            // 구매 시작
            B_GameManager.Instance.isBuyReady = true;
        }
    }

    void AkuBuySuccess()
    {
        if (B_GameManager.Instance.buySuccess)
        {
            speed = 100;
            transform.Translate(Vector3.right * speed * Time.deltaTime);    
            anim.SetBool("buying", false);
        }
    }

    void MoveToOrigin()
    {
        // 야쿠루가 구매를 다 하고 이동했을때 
        //transform.localPosition = originalPosition;
       // speed = 100;
    }
}
