using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_SpawnPoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable
    {
        get { return isPlaceable; }
        set { isPlaceable = value; }
    }
}
