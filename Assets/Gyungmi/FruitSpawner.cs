using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public static FruitSpawner instance;
    // 과일 스폰포인트를 담을 배열
    public Transform[] points;

    public GameObject[] fruits;
    public List<GameObject> fruitsList = new List<GameObject>();

    // 딸기 생성 주기
    float createTime = 5f;
    // 최대 갯수
    int maxNum = 8;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        points = GameObject.Find("FruitSpawnPoint").GetComponentsInChildren<Transform>();
    }

    public static FruitSpawner Instance
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

    void Start()
    {
        points = GameObject.Find("FruitSpawnPoint").GetComponentsInChildren<Transform>();

        
        if (points.Length > 0)
        {
            StartCoroutine(this.SpawnFruit());
        }
        
    }

    
    public IEnumerator SpawnFruit()
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

                GameObject fruit = Instantiate(selectedFruit, points[idx].position, points[idx].rotation);
                fruitsList.Add(fruit);
            }
            else
            {
                yield return null;
            }
        }
    }
    
    void Update()
    {
        if (points.Length > 0)
        {
            SpawnFruit();
        }
    }
}
