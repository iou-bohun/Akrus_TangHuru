using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Spawnner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] List<GameObject> spawnPointsList;
    B_SpawnManager spawnManager;

    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
        spawnManager = FindAnyObjectByType<B_SpawnManager>();
    }


   public  void Spawn()
    {
        Transform curSpawnPoint = null;
        while (curSpawnPoint == null)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            
          if (randomSpawnPoint.GetComponent<B_SpawnPoint>().IsPlaceable == true)
            {
                curSpawnPoint = randomSpawnPoint;
            }
           
        }
        if (curSpawnPoint != null)
        {
            GameObject tangHuru = spawnManager.Get(0);
            tangHuru.transform.position = curSpawnPoint.position;
            curSpawnPoint.GetComponent<B_SpawnPoint>().IsPlaceable = false;
        }
    }
}
