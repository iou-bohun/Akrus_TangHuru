using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_TestGrow : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DataManager.Instance.fruitCounts[FruitType.orange]++;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            DataManager.Instance.fruitCounts[FruitType.Strawberry]++;
        }
    }
}
