using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_GameManager : MonoBehaviour
{
    private static B_GameManager instance;
    public B_RestingContainer strawberryContainer;
    public B_RestingContainer grapeContainer;
    public B_RestingContainer orangeContaner;
    public B_RestingContainer pineappleContainer;
    public B_RestingContainer blueberryContainer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log(strawberryContainer.GetComponent<Transform>().position);
    }

    public static B_GameManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }
}
