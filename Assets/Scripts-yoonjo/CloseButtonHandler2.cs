using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CloseButtonHandler2 : MonoBehaviour
{
    public BackgroundPanelHandler backgroundPanel;
    public PanelHandler closepannel;
    public PanelHandler2 popupWindow;

    public void OnButtonClick()
    {
        SoundManager.Instance.PlayTapSound();
        var seq = DOTween.Sequence();

        seq.Append(transform.DOScale(0.95f, 0.1f));
        seq.Append(transform.DOScale(1.05f, 0.1f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play().OnComplete(() => {
            popupWindow.Hide();
            backgroundPanel.Hide();
            closepannel.Hide();
        });

    }
}

