using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_SpawnManager : MonoBehaviour
{
    public static B_SpawnManager instance;  
    public GameObject[] prefabs;
    List<GameObject>[] pools;

    private void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i < pools.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }

    public GameObject Get(int index, Vector3 transform, Quaternion quartanion)
    {
        GameObject select = null;
        foreach (GameObject item in pools[index])
        {
            if (item.activeSelf == false)
            {
                select = item;
                select.SetActive(true);
                break;
            }
        }
        if (select == null)
        {
            select = Instantiate(prefabs[index], transform, quartanion);
            pools[index].Add(select);
        }
        return select;
    }

}
