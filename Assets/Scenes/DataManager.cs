using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum FruitType
{
    Strawberry,
    Grape,
    orange,
    pineapple,
    blueberry
}

public enum FruitState
{
    noneTime,
    flowerTime,
    midTime
}

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public Dictionary<FruitType, int> fruitCounts = new Dictionary<FruitType, int>
    {
        {FruitType.Strawberry,1},
        {FruitType.Grape,0},
        {FruitType.orange,0},
        {FruitType.pineapple,0},
        {FruitType.blueberry,0},
    };
    public FruitType selectedFruit;
    public FruitType growFruit; // �ڶ�� ���� ����
    public FruitState growState;

    public int strawberryTangHuru;
    public int grapeTangHuru;
    public int orangeTangHuru;
    public int pineappleTangHuru;
    public int blueberryTangHuru;

    // �����̳�
    public int strawberryFruit;
    public int grapeFruit;
    public int orangeFruit;
    public int pineappleFruit;
    public int blueberryFruit;

    [SerializeField] int startingGold = 150;
    [SerializeField] int currentGold;
    [SerializeField] TextMeshProUGUI displayGold;
    [SerializeField] TextMeshProUGUI displayStarwberryTangHuru;
    [SerializeField] TextMeshProUGUI displayGrapeTanghuru;
    [SerializeField] TextMeshProUGUI displayOrangeTanghuru;
    [SerializeField] TextMeshProUGUI displayPineappleTanghuru;
    [SerializeField] TextMeshProUGUI displayBlueberryTanghuru;
    public int ruby;
    public bool isFruitAvaliable = false;
    public List<FruitType> avaliableFruits = new List<FruitType>();

    float strawberryPrepTime = 30f;
    float grapePrepTime = 30f;
    float orangePrepTime = 36f;
    float pineapplePrepTime = 36f;
    float blueberryPrepTime = 36f;

    public float strawberryGrowTime = 5f;
    float grapeGrowTime = 7f;
    float orangeGrowTime = 9f;
    float pineappleGrowTime = 11f;
    float blueberryGrowTime = 13f;


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
        currentGold = startingGold;
    }

    public static DataManager Instance
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
    private void Update()
    {
        CheckFruitCount();
        UpdateDisplay();
        UpdateStarawberryTangHuru();
    }

    /// <summary>
    /// ��� ����
    /// </summary>
    /// <param name="mount">  mount��ŭ ��� ����</param>
    public void Deposit(int mount)
    {
        currentGold += Mathf.Abs(mount);
    }
    /// <summary>
    ///  ��� ����
    /// </summary>
    /// <param name="mount">mount��ŭ ��� ����</param>
    public void Withdraw(int mount)
    {
        currentGold -= Mathf.Abs(mount);
    }

    /// <summary>
    /// ��� ���÷��� 
    /// </summary>
    void UpdateDisplay()
    {
        displayGold.text = "Gold:" + currentGold;
    }

    /// <summary>
    /// ��ġ�ҿ� ���ķ� �� ���÷��� 
    /// </summary>
    void UpdateStarawberryTangHuru()
    {
        displayStarwberryTangHuru.text = strawberryTangHuru.ToString();
        displayGrapeTanghuru.text  = grapeTangHuru.ToString();
        displayOrangeTanghuru.text = orangeTangHuru.ToString();
        displayPineappleTanghuru.text = pineappleTangHuru.ToString();
        displayBlueberryTanghuru.text = blueberryTangHuru.ToString();
    }

    /// <summary>
    /// ���� �����ҿ� ��� ������ ������ �ִ��� Ȯ�� 
    /// </summary>
    void CheckFruitCount()
    {
        if (fruitCounts[FruitType.Strawberry]<=0 && fruitCounts[FruitType.Grape]<=0&&
            fruitCounts[FruitType.orange] <= 0&& fruitCounts[FruitType.pineapple]<=0&& fruitCounts[FruitType.blueberry]<=0)
        {
            isFruitAvaliable = false;
        }
        else { isFruitAvaliable = true; }
    }

    /// <summary>
    /// ��밡���� ������ �������� ����
    /// </summary>
    public void SelectRandomFruit()
    {
        avaliableFruits.Clear();
        foreach(var fruit in fruitCounts.Keys ) //��� ������ �����Ǿ��ֳ� 
        {
            if (fruitCounts[fruit] > 0)  //������ 1�� �̻� �����Ǿ��ִٸ� 
            {
                avaliableFruits.Add(fruit); // ��밡���� ���Ͽ� �� ������ ������ �߰� 
            }
        }
        if(avaliableFruits.Count > 0) // ��� ������  ������ ������ �ִٸ� 
        {
            int randomIndex = Random.Range(0, avaliableFruits.Count);
            selectedFruit = avaliableFruits[randomIndex]; // ������ ���� �������� ���� 
        }
    }
    public float SelectedFruitPrepTime()
    {
        switch (selectedFruit)
        {
            case FruitType.Strawberry:
                return strawberryPrepTime;
            case FruitType.Grape:
                return grapePrepTime;
            case FruitType.orange:
                return orangePrepTime;
            case FruitType.pineapple:
                return pineapplePrepTime;
            case FruitType.blueberry:
                return blueberryPrepTime;
            default:
                return 0f;
        }
    }
}
