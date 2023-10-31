using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // 과일 스폰포인트를 담을 배열
    public Transform[] points;

    // 딸기 프리팹
    public GameObject strawberryPrefab;

    // 딸기 생성 주기
    float createTime = 5f;
    // 최대 갯수
    int maxNum = 8;
    
    void Start()
    {
        points = GameObject.Find("FruitSpawnPoint").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            StartCoroutine(this.SpawnFruit());
        }
    }

    IEnumerator SpawnFruit()
    {
        while(true)
        {
            int fruitCount = (int)GameObject.FindGameObjectsWithTag("Fruit").Length;

            if (fruitCount < maxNum)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);

                Instantiate(strawberryPrefab, points[idx].position, points[idx].rotation);

            }
            else
            {
                yield return null;
            }
        }

    }

    void Update()
    {
        
    }
}
