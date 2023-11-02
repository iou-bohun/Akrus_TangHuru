using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public static Container instance;

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
    }

    public static Container Instance 
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
        
    }

    void Update()
    {
        
    }
}
