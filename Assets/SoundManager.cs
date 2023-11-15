using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public AudioSource audioSource;
    public AudioClip tapClip;
    public AudioClip rolletClip;
    public Toggle soundToggle; // 이 토글은 사운드를 제어하는 데 사용됩니다.


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static SoundManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public void PlayTapSound()
    {
        if (soundToggle.isOn) // 토글이 켜져 있는 경우에만 사운드 재생
        {
            audioSource.PlayOneShot(tapClip);
        }
    }

    public void playRulletSound()
    {
        if (soundToggle.isOn) // 토글이 켜져 있는 경우에만 사운드 재생
        {
            audioSource.PlayOneShot(rolletClip);
        }
    }
}
