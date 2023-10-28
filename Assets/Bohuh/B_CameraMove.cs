using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_CameraMove : MonoBehaviour
{
    public Transform[] targetPosition;
    int backgroundNum = 0;
    [SerializeField] int maxBackgroundNum = 3;

    public void RightButtonMove()
    {
        backgroundNum++;
        if(backgroundNum >= maxBackgroundNum)
        {
            backgroundNum = 0;
        }
        Camera.main.transform.position = 
            new Vector3(targetPosition[backgroundNum].transform.position.x, 
            targetPosition[backgroundNum].transform.position.y, -10);
    }

    public void LeftButtonMove()
    {
        backgroundNum--;
        if(backgroundNum < 0)
        {
            backgroundNum = maxBackgroundNum - 1;
        }
        Camera.main.transform.position =
             new Vector3(targetPosition[backgroundNum].transform.position.x,
             targetPosition[backgroundNum].transform.position.y, -10);
    }

}
