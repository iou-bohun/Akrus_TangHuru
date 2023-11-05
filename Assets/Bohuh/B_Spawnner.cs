using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class B_Spawnner : MonoBehaviour
{
    private static B_Spawnner instance;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] List<GameObject> spawnPointsList;
    B_SpawnManager spawnManager;
    public Transform randomSpawnPoint;
    Vector3 position;

    private void Awake()
    {
        instance = this;
        spawnPoints = GetComponentsInChildren<Transform>();
        spawnManager = FindAnyObjectByType<B_SpawnManager>();
    }

    public static B_Spawnner Instance
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

   public  void Spawn()
    {
        Transform curSpawnPoint = null;
        while (curSpawnPoint == null)
        {
          randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
          position = randomSpawnPoint.position;
          if (randomSpawnPoint.GetComponent<B_SpawnPoint>().IsPlaceable == true)
            {
                curSpawnPoint = randomSpawnPoint;
            }
        }
        if (curSpawnPoint != null)
        {
            GameObject tangHuru = spawnManager.Get(((int)DataManager.Instance.selectedFruit),position, randomSpawnPoint.rotation);
            DataManager.Instance.fruitCounts[DataManager.Instance.selectedFruit]--;
            tangHuru.transform.position = curSpawnPoint.position;
            curSpawnPoint.GetComponent<B_SpawnPoint>().IsPlaceable = false;
        }
    }
}
