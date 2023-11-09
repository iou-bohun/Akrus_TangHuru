using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fruit : MonoBehaviour
{
    public static Fruit instance;
    public bool isHarvestingReady = false;

    public float maxTime = 0;
    public float curruntTime;

    /// <summary>
    /// test
    /// </summary>
    public Sprite[] fruitStep;
    public float changeTimer;
    private SpriteRenderer sp;
    private float curTimer = 0.0f;
    private bool changeAt = false;
    private int spriteIndex = 0;


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
    }

    public static Fruit Instance
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

    //private void OnEnable()
    //{
        /*
        if (DataManager.Instance.growFruit == FruitType.Strawberry)
        {
            maxTime = 15f;
        }
        else if (DataManager.Instance.growFruit == FruitType.Grape)
        {
            maxTime = 21f;
        }
        else if (DataManager.Instance.growFruit == FruitType.orange)
        {
            maxTime = 27f;
        }
        else if (DataManager.Instance.growFruit == FruitType.pineapple)
        {
            maxTime = 33f;
        }
        else if (DataManager.Instance.growFruit == FruitType.blueberry)
        {
            maxTime = 39f;
        }
        curruntTime = maxTime;
        changeTimer = maxTime/3;
        //growBar.value = ((float)curruntTime/3) / ((float)maxTime/3f);
        */
    //}

    public void FruitStateChange()
    {
        //if (DataManager.Instance.growState == FruitState.fin)
        //{
        //    isHarvestingReady = true;
        //}
    }

    void GrowFruit()
    {

    }


    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        sp.RegisterSpriteChangeCallback(OnSpriteChanged);
    }

    private void OnSpriteChanged(SpriteRenderer sp)
    {
        curTimer = 0f;
        if(sp.sprite.name != fruitStep[fruitStep.Length - 1].name)
        {
            //if(curTimer > flowerTime)
            changeAt = true;
            spriteIndex++;
        }
        else
        {
            changeAt = false;
        }
    }

    void Update()
    {
        curTimer += Time.deltaTime;
        //if (curTimer > DataManager.Instance.strawberryGrowTime)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            spriteIndex = 0;
            sp.sprite = fruitStep[0];
            curTimer = 0f;
        }
        if (curTimer > maxTime)
        {
            isHarvestingReady = true;

        }
        if(changeAt)
        {
            curTimer += Time.deltaTime;
            if(curTimer > changeTimer)
            {
                sp.sprite = fruitStep[spriteIndex];
            }
        }
    }
}
