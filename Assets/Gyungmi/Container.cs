using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Container : MonoBehaviour, IPointerClickHandler
{
    public static Container instance;
    int strawberryNum;
    int orangeNum;
    int pineappleNum;
    int grapeNum;
    int blueberryNum;




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

    public void Harvest()
    {

    }


    public void OnPointerClick(PointerEventData eventData)
    {
        /*
        Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitInfo = Physics2D.Raycast(touchPos, Camera.main.transform.forward);
        if(hitInfo.collider != null)
        {
            GameObject touchFruit = hitInfo.transform.gameObject;
        }
        Debug.Log(gameObject.name(touchFruit));*/
        string curName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(curName);
        //throw new System.NotImplementedException();
    }
}
