using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RouletteController : MonoBehaviour
{
    public Transform arrow; // 화살표 오브젝트
    public Transform rouletteWheel; // 룰렛의 원판
    public float initialRotationSpeed = 100.0f; // 초기 룰렛 회전 속도
    public float finalRotationSpeed = 20.0f; // 최종 룰렛 회전 속도 (감속 시)
    public float decelerationTime = 1.0f; // 감속이 시작되는 시간 (5초 전체 시간 중)
    public float minRotationSpeed = 80.0f; // 최소 룰렛 회전 속도
    public float maxRotationSpeed = 120.0f; // 최대 룰렛 회전 속도
    public Sprite spinningSprite; // 회전 중일 때의 이미지
    public Sprite idleSprite; // 기본 상태의 이미지

    private bool isSpinning = false; // 룰렛 회전 중인지 여부
    private float rotationSpeed; // 현재 룰렛 회전 속도
    private string[] items = { "딸기X1", "코인X10", "코인X20", "코인X30", "루비X40", "루비X1", "루비X2", "딸기X1" };
    private float spinTime = 0.0f; // 룰렛 회전 시간 측정
    private float targetAngle; // 룰렛이 멈추게 될 각도

    void Start()
    {
        // 버튼 클릭 시 SpinRoulette 함수 실행
        GetComponent<Button>().onClick.AddListener(SpinRoulette);
        rotationSpeed = initialRotationSpeed;
        targetAngle = Random.Range(-360, 360);
    }

    void Update()
    {
        if (isSpinning)
        {
            float step = rotationSpeed * Time.deltaTime;
            rouletteWheel.Rotate(0, 0, -step);

            spinTime += Time.deltaTime;

            if (spinTime >= (5.0f - decelerationTime)) // 감속 시작 시간 계산
            {
                rotationSpeed = Mathf.Lerp(initialRotationSpeed, finalRotationSpeed, (spinTime - (5.0f - decelerationTime)) / decelerationTime); // 감속 시간에 따라 속도 감소
            }

            if (spinTime >= 5.0f) // 5초에 도달하면 회전을 멈춥니다.
            {
                rotationSpeed = 0;
                isSpinning = false;
                CalculateResult();
            }
        }
    }

    public void SpinRoulette()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            spinTime = 0.0f;

            // 랜덤한 회전 속도 설정
            rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

            GetComponent<Image>().sprite = spinningSprite; // 버튼 이미지를 회전 중 이미지로 변경합니다.

            // 화살표의 회전 각도를 기준으로 룰렛의 회전 각도 설정
            float arrowAngle = arrow.eulerAngles.z;
            rouletteWheel.rotation = Quaternion.Euler(0, 0, arrowAngle);

            // 랜덤한 각도 계산
            targetAngle = Random.Range(720, 1080); // 랜덤한 몇 바퀴 후 멈출지 결정 (2바퀴 ~ 3바퀴)
            targetAngle += arrowAngle; // 화살표 각도를 더해 원판이 멈출 각도 결정
        }
    }

    void CalculateResult()
    {
        // 원판의 회전 각도를 0에서 360 범위로 변환하여 처리
        float wheelAngle = rouletteWheel.eulerAngles.z;
        wheelAngle = (wheelAngle + 360) % 360; // 음수 각도 처리

        float normalizedAngle = wheelAngle - (360 * Mathf.FloorToInt(wheelAngle / 360)); // 0도에서 360도 사이의 각도로 변환

        // 원하는 각도 범위 내에 있는지 확인
        int index = Mathf.FloorToInt(normalizedAngle / 45);

        //Debug.Log("Index at 0 degree reference line: " + index);
        Debug.Log("Result: " + items[index]);

        GetComponent<Image>().sprite = idleSprite; // 버튼 이미지를 기본 이미지로 변경합니다.
    }
}
