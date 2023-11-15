using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class G_FruitSpawn : MonoBehaviour
{
    FruitData[] fruitData;
    public static G_FruitSpawn instance;
    [SerializeField]
    private List<FruitData> fruitDatas = new List<FruitData>(); // 과일 종류
    [SerializeField]
    private GameObject fruitPrefab;

    

    public Transform[] points; // 스폰 포인트
    Transform curSpawnPoint;
    FruitData selectedFruit;
    Vector3 position;
    private Sprite sprite;
    int idx;

    public List<FruitData> fruitList = new List<FruitData>(); // 랜덤선택한 과일이 들어갈 리스트
    
    int maxNum = 8;


    private void Awake()
    {
        points = GameObject.Find("FruitSpawnPoint").GetComponentsInChildren<Transform>();
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    public static G_FruitSpawn Instance
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

    // 스폰할 과일 고르기
    public void randomSelect()
    {
        int selection = 0;
        if (fruitList.Count < 8)
        {
            selection = Random.Range(0, fruitDatas.Count);
            selectedFruit = fruitDatas[selection];
            fruitList.Add(selectedFruit); // 랜덤으로 선택된 과일을 fruitList에 추가
        }
    }



    public IEnumerator SpawnFruit()
    {
        
        if(fruitList.Count <= maxNum)
        { 
            curSpawnPoint = null;
            while(fruitList.Count < 9)
            {
                randomSelect();
                int randomFruit = Random.Range(0, fruitDatas.Count);
                idx = Random.Range(0, points.Length); // 랜덤 스폰포인트 위치를 찾아서
                if (points[idx].GetComponent<FruitSpawnPoint>().IsPlaceable == true) // 만약 고른 스폰포인트의 isplaceable이 true이면 
                {
                    yield return new WaitForSeconds(selectedFruit.None_time);
                    curSpawnPoint = points[idx]; // 현재 스폰 포인트에 
                    position = curSpawnPoint.position;
                    var fruit = SpawnFunc((FruitType)randomFruit);
                    sprite = selectedFruit.FlowerSprite;
                    Instantiate(fruit, position, points[idx].rotation);
                }
                //else
                //{
                    //yield return null;
                //}
   
            }   
        }
        /*
        randomSelect();
        int randomFruit = Random.Range(0, fruitDatas.Count);
        yield return new WaitForSeconds(selectedFruit.None_time);
        var fruit = SpawnFunc((FruitType)randomFruit);
        sprite = selectedFruit.FlowerSprite;
        */
    }

    public B_FruitScript SpawnFunc(FruitType type)
    {
        var newFruit = Instantiate(fruitPrefab).GetComponent<B_FruitScript>();
        newFruit.FruitData = fruitDatas[(int)type];
        curSpawnPoint.GetComponent<FruitSpawnPoint>().IsPlaceable = false;
        curSpawnPoint = null;
        return newFruit;
    }

    void Update()
    {
        
    }
}
