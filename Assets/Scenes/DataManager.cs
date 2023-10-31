using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum FruitType
{
    Strawberry,
    Grape,
    orange
}

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    Dictionary<FruitType, int> fruitCounts = new Dictionary<FruitType, int>
    {
        { FruitType.Strawberry,3},
        {FruitType.Grape,2},
        {FruitType.orange,1},
    };
    public FruitType selectedFruit;

    public int strawberryTangHuru;
    [SerializeField] int startingGold = 150;
    [SerializeField] int currentGold;
    [SerializeField] TextMeshProUGUI displayGold;
    [SerializeField] TextMeshProUGUI displayStarwberryTangHuru;
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

    void UpdateStarawberryTangHuru()
    {
        displayStarwberryTangHuru.text = strawberryTangHuru.ToString();
    }

    void CheckFruitCount()
    {
        if (fruitCounts[FruitType.Strawberry]<=0 && fruitCounts[FruitType.Grape]<=0&&
            fruitCounts[FruitType.orange] <= 0)
        {
            isFruitAvaliable = false;
        }
        else { isFruitAvaliable = true; }
    }

    public void SelectRandomFruit()
    {
        foreach(var fruit in fruitCounts.Keys )
        {
            if (fruitCounts[fruit] > 0)
            {
                avaliableFruits.Add(fruit);
            }
        }
        if(avaliableFruits.Count > 0)
        {
            int randomIndex = Random.Range(0, avaliableFruits.Count);
            selectedFruit = avaliableFruits[randomIndex];
            fruitCounts[selectedFruit]--;
            Debug.Log(selectedFruit + "남은 개수 : " + fruitCounts[selectedFruit]);
        }
        else
        {
            Debug.Log("과일 없음");
        }
    }
}
