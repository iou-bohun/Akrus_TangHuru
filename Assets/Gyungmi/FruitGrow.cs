using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitGrow : MonoBehaviour
{
    [SerializeField]
    private string fruitName;
    [SerializeField]
    private Image flowerImage;
    [SerializeField]
    private Image midImage;
    [SerializeField]
    private Image finImage;
    [SerializeField]
    private Image curImage;
    [SerializeField]
    private float noneTime;
    [SerializeField]
    private float flowerTime;
    [SerializeField]
    private float midTime;

    private Sprite[] sprite = new Sprite[3];
    private float[] times = new float[3];

    [SerializeField]
    private float curTime;
    public FruitSpawn fruitSpawn;

    public bool isGrowing = false;
    public bool growingStart = false;
    public bool isGathering = true;
    private int index = 0;


    public void SetUp(FruitData fruitData)
    {
        growingStart = true;
        isGathering = false;

        fruitName = fruitData.FruitName;
        flowerImage.sprite = fruitData.FlowerSprite;
        midImage.sprite = fruitData.MiddleFruitSprite;
        finImage.sprite = fruitData.FruitSprite;
        noneTime = fruitData.None_time;
        flowerTime = fruitData.Flower_Time;
        midTime = fruitData.Mid_Time;

        sprite[0] = flowerImage.sprite;
        sprite[1] = midImage.sprite;
        sprite[2] = finImage.sprite;

        times[0] = noneTime;
        times[1] = flowerTime;
        times[2] = midTime;
    }
    void Update()
    {
        if (growingStart)
        {
            growingStart = false;
            isGrowing = true;
        }

        if(isGrowing)
        {
            curTime += Time.deltaTime;
            if(curTime >= times[index])
            {
                
                Color color = curImage.color;
                if(color.a == 0)
                {
                    color.a = 255;
                    curImage.color = color;
                }
                

                curImage.sprite = sprite[index];

                index++;
                if (index == 3)
                {
                    index = 0;
                    curImage.GetComponent<Button>().interactable = true;
                    isGrowing = false;
                }
                curTime = 0;
            }
        }
    }

    public void Accel()
    {
        if(isGrowing)
        {
            curTime += 3f;
        }
    }

    public void Gathering()
    {
        isGathering = true;
        Color color = curImage.color;
        color.a = 0;
        curImage.color = color;
        curImage.GetComponent<Button>().interactable = false;

        if (fruitName == "strawberry")
        {
            DataManager.Instance.fruitCounts[FruitType.Strawberry]++;
        }
        else if (fruitName == "blueberry")
        {
            DataManager.Instance.fruitCounts[FruitType.blueberry]++;
        }
        else if (fruitName == "orange")
        {
            DataManager.Instance.fruitCounts[FruitType.orange]++;
        }
        else if (fruitName == "grape")
        {
            DataManager.Instance.fruitCounts[FruitType.Grape]++;
        }
        else if (fruitName == "pineapple")
        {
            DataManager.Instance.fruitCounts[FruitType.pineapple]++;
        }
    }
}
