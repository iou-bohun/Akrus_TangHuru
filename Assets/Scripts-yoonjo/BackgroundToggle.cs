using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundToggle : MonoBehaviour
{
    [SerializeField] Image toggleImage; // Image 컴포넌트가 있는 UI 요소를 여기에 할당해야 합니다.
    public Sprite imageWhenOn; // 토글이 켜진 상태에서 보여질 이미지
    public Sprite imageWhenOff; // 토글이 꺼진 상태에서 보여질 이미지
    public AudioSource backgroundMusic; // 배경음악 AudioSource

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
        {
            toggleImage.sprite = imageWhenOn;
            // 배경음악을 켭니다.
            if (backgroundMusic != null)
            {
                backgroundMusic.Play();
            }
        }
        else
        {
            toggleImage.sprite = imageWhenOff;
            // 배경음악을 끕니다.
            if (backgroundMusic != null)
            {
                backgroundMusic.Stop();
            }
        }
    }
}

