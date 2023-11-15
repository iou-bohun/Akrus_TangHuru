using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ButtonHandler2 : MonoBehaviour
{
    public GameObject backgroundPanel;

    public PanelHandler2 popupWindow;

    public void OnButtonClick()
    {
        SoundManager.Instance.PlayTapSound();

        backgroundPanel.SetActive(true);
        popupWindow.Show();

    }
}
