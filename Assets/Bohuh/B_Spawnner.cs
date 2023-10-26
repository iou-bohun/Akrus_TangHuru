using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Spawnner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    B_SpawnManager spawnManager;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        spawnManager = FindAnyObjectByType<B_SpawnManager>();
    }


   public  void Spawn()
    {
        Transform curSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        if (curSpawnPoint.GetComponent<B_SpawnPoint>().IsPlaceable == true)
        {
            GameObject tangHuru = spawnManager.Get(0);
            tangHuru.transform.position = curSpawnPoint.position;
            curSpawnPoint.GetComponent<B_SpawnPoint>().IsPlaceable = false;
        }
    }
}
