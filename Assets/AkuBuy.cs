using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AkuBuy : MonoBehaviour
{
    [SerializeField] float speed = 100;
    Vector2 originalPosition;
    Animator anim;
    enum akuStatus { up=0, wating=1, right}
    int dir;
    private void Awake()
    {
        originalPosition = this.transform.localPosition;
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        dir = (int)akuStatus.up;
    }

    private void Update()
    {
        AkuMove();
        AkuBuySuccess();
        if(transform.localPosition.x > 8)
        {
            MoveToOrigin();
        }
    }
   
    void AkuBuySuccess()
    {
        if (B_GameManager.Instance.buySuccess)
        {
            anim.SetBool("buying", false);
            dir = (int)akuStatus.right;
            B_GameManager.Instance.isBuyReady = false;
            B_GameManager.Instance.buySuccess = false;
        }
    }

    void AkuMove()
    {
        switch (dir)
        {
            case (int)akuStatus.up:
                transform.Translate(Vector3.up*speed * Time.deltaTime);
                break;
            case (int)akuStatus.wating:
                break;
            case (int)akuStatus.right:
                transform.Translate(Vector3.right*speed * Time.deltaTime);
                break;
        }
    }

    void MoveToOrigin()
    {
        transform.localPosition = originalPosition;
        dir = (int)akuStatus.up;    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dir = (int)akuStatus.wating;
        anim.SetBool("buying", true);
        B_GameManager.Instance.isBuyReady = true;
    }
}
