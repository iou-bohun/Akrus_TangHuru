using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class B_TangHuru : MonoBehaviour
{
    [SerializeField] GameObject restingContainer;
    Vector3 mousePositionOffset;
    Vector3 resetPosition;

    private void Start()
    {
        resetPosition = this.transform.position;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
           transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }
    private void OnMouseUp()
    {
        if(Mathf.Abs(this.transform.localPosition.x - restingContainer.transform.localPosition.x)<=0.5f &&
            Mathf.Abs(this.transform.localPosition.y - restingContainer.transform.localPosition.y) <= 0.5f)
        {
            this.transform.localPosition = 
                new Vector3(restingContainer.transform.localPosition.x, restingContainer.transform.localPosition.y, restingContainer.transform.localPosition.z);
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }
   
}
