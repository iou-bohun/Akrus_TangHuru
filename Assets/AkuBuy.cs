using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AkuBuy : MonoBehaviour
{
    public TMP_Text levelUIText;
    public TMP_Text levelText;
    public TMP_Text expText;

    [SerializeField] UnityEngine.UI.Slider expbar;
    [SerializeField] float speed = 100;

    Vector2 originalPosition;
    Animator anim;

    float maxExp = 3;
    float curExp = 0;

    public int level = 1;

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
        expbar.value = (float)curExp / (float)maxExp; // Exp의 값을 0/100 으로 시작
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
            HandleExp();
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


    private void HandleExp()
    {
        Debug.Log("경험치 증가");
        curExp += 1;

        expbar.value = (float)curExp / (float)maxExp; // Handle의 값 0/100

        if (expbar.value >= 1)
        {
            expbar.value = expbar.value - 1;
            level++;
            levelUIText.text = level.ToString();
            levelText.text = level.ToString();

            if (level <= 6)
            {
                maxExp += 5;
            }
            else
                maxExp += 6;
        }

        expText.text = curExp.ToString() + "/" + maxExp.ToString();
    }
}
