using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Container : MonoBehaviour
{
    public static Container instance;
    [SerializeField] Button strawberryFirst;
    [SerializeField] Button grapeFirst;
    [SerializeField] Button orangeFirst;
    [SerializeField] Button pineappleFirst;
    [SerializeField] Button blueberryFirst;
    private bool isChoose = false;

    private ColorBlock sColor;
    private ColorBlock gColor;
    private ColorBlock oColor;
    private ColorBlock pColor;
    private ColorBlock bColor;

    public GameObject selectedFirst;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        sColor = strawberryFirst.colors;
        gColor = grapeFirst.colors;
        oColor = orangeFirst.colors;
        pColor = pineappleFirst.colors;
        bColor = blueberryFirst.colors;
    }

    public static Container Instance 
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

    public void OnButtonClick()
    {
        Debug.Log(DataManager.Instance.isFirstPrep);
        isChoose = !isChoose;
        DataManager.Instance.isFirstPrep = !DataManager.Instance.isFirstPrep;

        sColor.normalColor = isChoose ? new Color(0.8f, 0.8f, 0.8f, 1f) : Color.white;
        sColor.selectedColor = isChoose ? new Color(0.8f, 0.8f, 0.8f, 1f) : Color.white;
        strawberryFirst.colors = sColor;

        gColor.normalColor = isChoose ? new Color(0.8f, 0.8f, 0.8f, 1f) : Color.white;
        gColor.selectedColor = isChoose ? new Color(0.8f, 0.8f, 0.8f, 1f) : Color.white;
        grapeFirst.colors = sColor;

        oColor.normalColor = isChoose ? new Color(0.8f, 0.8f, 0.8f, 1f) : Color.white;
        oColor.selectedColor = isChoose ? new Color(0.8f, 0.8f, 0.8f, 1f) : Color.white;
        orangeFirst.colors = sColor;

        pColor.normalColor = isChoose ? new Color(0.8f, 0.8f, 0.8f, 1f) : Color.white;
        pColor.selectedColor = isChoose ? new Color(0.8f, 0.8f, 0.8f, 1f) : Color.white;
        pineappleFirst.colors = sColor;

        bColor.normalColor = isChoose ? new Color(0.8f, 0.8f, 0.8f, 1f) : Color.white;
        bColor.selectedColor = isChoose ? new Color(0.8f, 0.8f, 0.8f, 1f) : Color.white;
        blueberryFirst.colors = sColor;

        selectedFirst = EventSystem.current.currentSelectedGameObject;
        Debug.Log(selectedFirst);
    }
}
