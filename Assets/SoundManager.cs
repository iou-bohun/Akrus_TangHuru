using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public AudioSource audioSource;
    public AudioClip tapClip;
    public AudioClip rolletClip;


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
        audioSource.PlayOneShot(tapClip);
    }

    public void playRulletSound()
    {
        audioSource.PlayOneShot(rolletClip); 
    }
}
