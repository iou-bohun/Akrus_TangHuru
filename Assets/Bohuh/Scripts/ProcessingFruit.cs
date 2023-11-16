using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessingFruit : MonoBehaviour
{
    public GameObject fruit;
    SpriteRenderer chlidrenSprite;
    [SerializeField] Sprite[] sprite;

    private void Awake()
    {
        chlidrenSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       if(DataManager.Instance.selectedFruit == FruitType.Strawberry)
        {
            fruit.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);   
        }
        else
        {
            fruit.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
      if(DataManager.Instance.isFruitAvaliable == true)
        {
            SetPrecessingFruitActive(true);
            chlidrenSprite.sprite = sprite[(int)DataManager.Instance.selectedFruit];
        }
        else
        {
            SetPrecessingFruitActive(false);
        }
    }
    void SetPrecessingFruitActive(bool isActive)
    {
           fruit.gameObject.SetActive(isActive);
    }
}
