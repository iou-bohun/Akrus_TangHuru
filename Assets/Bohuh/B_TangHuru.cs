using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class B_TangHuru : MonoBehaviour
{
    Transform targetConrainer;
    Vector3 mousePositionOffset;
    Vector3 resetPosition;

    private void Start()
    {
        resetPosition = this.transform.position;
    }

    private void OnEnable()
    {
        targetConrainer = B_GameManager.Instance.restingContainer.GetComponent<Transform>();
    }
    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    /// <summary>
    /// 마우스 클릭시
    /// </summary>
    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }
    /// <summary>
    /// 마우스 드래그
    /// </summary>
    private void OnMouseDrag()
    {
           transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }
    /// <summary>
    /// 마우스 언클릭시
    /// </summary>
    private void OnMouseUp()
    {
        ///탕후루와 구치소가 충돌한 경우 
        if(Mathf.Abs(this.transform.localPosition.x - targetConrainer.transform.localPosition.x)<=0.5f &&
            Mathf.Abs(this.transform.localPosition.y - targetConrainer.transform.localPosition.y) <= 0.5f)
        {
            this.transform.localPosition = 
                new Vector3(targetConrainer.transform.localPosition.x, targetConrainer.transform.localPosition.y, targetConrainer.transform.localPosition.z);
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
   
}
