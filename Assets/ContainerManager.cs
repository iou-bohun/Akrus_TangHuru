using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerManager : MonoBehaviour
{
    private static ContainerManager instance;

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
    }
    public static ContainerManager Instance
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


}
