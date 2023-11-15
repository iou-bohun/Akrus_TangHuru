using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUi : MonoBehaviour
{
    [SerializeField] Image toggleImage; // Image 컴포넌트가 있는 UI 요소를 여기에 할당해야 합니다.
    public Sprite imageWhenOn; // 토글이 켜진 상태에서 보여질 이미지
    public Sprite imageWhenOff; // 토글이 꺼진 상태에서 보여질 이미지

    Toggle toggle;

    void Awake()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnSwitch);

        if (toggle.isOn)
            OnSwitch(true);
        else
            OnSwitch(false);
    }

    public void OnSwitch(bool on)
    {
        if (on)
            toggleImage.sprite = imageWhenOn;

        else
            toggleImage.sprite = imageWhenOff;
    }
}