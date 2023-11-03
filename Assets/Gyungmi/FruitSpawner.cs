using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    // 과일 스폰포인트를 담을 배열
    public Transform[] points;

    // 딸기 프리팹
    // public GameObject strawberryPrefab;
    public GameObject[] fruits;
    private List<GameObject> gameObject = new List<GameObject>();

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
        while (true)
        {
            int selection = Random.Range(0, fruits.Length); // 과일 프리팹 랜덤 선택
            GameObject selectedFruit = fruits[selection];
            int fruitCount = (int)GameObject.FindGameObjectsWithTag("Fruit").Length;

            if (fruitCount < maxNum)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);

                GameObject instance = Instantiate(selectedFruit, points[idx].position, points[idx].rotation);
                gameObject.Add(instance);
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
