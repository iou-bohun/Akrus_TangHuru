using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnPoint : MonoBehaviour
{
    [SerializeField] public GameObject fruit;
    [SerializeField] bool isPlaceable;

    public bool IsPlaceable { get { return isPlaceable; } }
}
