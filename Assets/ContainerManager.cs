using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContainerManager : MonoBehaviour
{
    private static ContainerManager instance;

    public B_RestingContainer strawberryContainer;
    public B_RestingContainer grapeContainer;
    public B_RestingContainer orangeContaner;
    public B_RestingContainer pineappleContainer;
    public B_RestingContainer blueberryContainer;

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

    [SerializeField] GameObject selectedFirst;


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

        sColor = strawberryFirst.colors;
        gColor = grapeFirst.colors;
        oColor = orangeFirst.colors;
        pColor = pineappleFirst.colors;
        bColor = blueberryFirst.colors;
    }
    public static ContainerManager Instance
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

        //selectedFirst = EventSystem.current.currentSelectedGameObject;
        selectedFirst = isChoose? EventSystem.current.currentSelectedGameObject : null; 


        Debug.Log(selectedFirst);
    }
}
