using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        // transform �� scale ���� ��� 0.1f�� �����մϴ�.
        transform.localScale = Vector3.one * 0.1f;
        // ��ü�� ��Ȱ��ȭ �մϴ�.
        gameObject.SetActive(false);
    }
    public void Show()
    {
        gameObject.SetActive(true);

        // DOTween �Լ��� ���ʴ�� �����ϰ� ���ݴϴ�.
        var seq = DOTween.Sequence();

        // DOScale �� ù ��° �Ķ���ʹ� ��ǥ Scale ��, �� ��°�� �ð��Դϴ�.
        seq.Append(transform.DOScale(1.1f, 0.2f));
        seq.Append(transform.DOScale(1f, 0.1f));

        seq.Play();
    }

    public void Hide()
    {
        var seq = DOTween.Sequence();

        transform.localScale = Vector3.one * 0.2f;

        seq.Append(transform.DOScale(1.1f, 0.1f));
        seq.Append(transform.DOScale(0.2f, 0.2f));

        // OnComplete �� seq �� ������ �ִϸ��̼��� �÷��̰� �Ϸ�Ǹ�
        // { } �ȿ� �ִ� �ڵ尡 ����ȴٴ� �ǹ��Դϴ�.
        // ���⼭�� �ݱ� �ִϸ��̼��� �Ϸ�� �� ��ÿ�� ��Ȱ��ȭ �մϴ�.
        seq.Play().OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
