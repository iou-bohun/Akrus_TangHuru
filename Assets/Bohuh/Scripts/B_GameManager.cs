using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_GameManager : MonoBehaviour
{
    private static B_GameManager instance;
    public bool isBuyReady = false;
    public bool buySuccess = false;

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
