using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void OnClick()
    {
        SoundManager.Instance.PlayTapSound();
    }
}
