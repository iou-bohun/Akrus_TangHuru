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

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public Dictionary<FruitType, int> fruitCounts = new Dictionary<FruitType, int>
    {
        { FruitType.Strawberry,1},
        {FruitType.Grape,1},
        {FruitType.orange,1},
        {FruitType.pineapple,1},
        {FruitType.blueberry,1},
    };
    public FruitType selectedFruit;

    public int strawberryTangHuru;
    public int grapeTangHuru;
    public int orangeTangHuru;
    public int pineappleTangHuru;
    public int blueberryTangHuru;
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
        UpdateDisplay();
        UpdateStarawberryTangHuru();
        CheckFruitCount();
        Debug.Log(isFruitAvaliable);
    }

    /// <summary>
    /// 골드 증가
    /// </summary>
    /// <param name="mount">  mount만큼 골드 증가</param>
    public void Deposit(int mount)
    {
        currentGold += Mathf.Abs(mount);
    }
    /// <summary>
    ///  골드 감소
    /// </summary>
    /// <param name="mount">mount만큼 골드 감소</param>
    public void Withdraw(int mount)
    {
        currentGold -= Mathf.Abs(mount);
    }

    /// <summary>
    /// 골드 디스플레이 
    /// </summary>
    void UpdateDisplay()
    {
        displayGold.text = "Gold:" + currentGold;
    }

    /// <summary>
    /// 구치소에 탕후루 수 디스플레이 
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
    /// 현제 보관소에 사용 가능한 과일이 있는지 확인 
    /// </summary>
    void CheckFruitCount()
    {
        if (fruitCounts[FruitType.Strawberry]<=0 && fruitCounts[FruitType.Grape]<=0&&
            fruitCounts[FruitType.orange] <= 0&& fruitCounts[FruitType.pineapple]<=00&& fruitCounts[FruitType.blueberry]<=0)
        {
            isFruitAvaliable = false;
        }
        else { isFruitAvaliable = true; }
    }

    /// <summary>
    /// 사용가능한 과일을 랜덤으로 선택
    /// </summary>
    public void SelectRandomFruit()
    {
        avaliableFruits.Clear();
        foreach(var fruit in fruitCounts.Keys ) //어떠한 과일이 보관되어있나 
        {
            if (fruitCounts[fruit] > 0)  //과일이 1개 이상 보관되어있다면 
            {
                avaliableFruits.Add(fruit); // 사용가능한 과일에 그 과일의 종류를 추가 
            }
        }
        if(avaliableFruits.Count > 0) // 사용 가능한  과일의 종류가 있다면 
        {
            int randomIndex = Random.Range(0, avaliableFruits.Count);
            selectedFruit = avaliableFruits[randomIndex]; // 과일의 종류 랜덤으로 선택 
            fruitCounts[selectedFruit]--; // 선택된 과일의 수 감소 
        }
    }
}
