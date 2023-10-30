using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    public int strawberry;
    public int strawberryTangHuru = 0;
    [SerializeField] int startingGold = 150;
    [SerializeField] int currentGold;
    [SerializeField] TextMeshProUGUI displayGold;
    [SerializeField] TextMeshProUGUI displayStarwberryTangHuru;
    public int ruby;

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
}
