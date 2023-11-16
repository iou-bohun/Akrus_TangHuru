using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKuMove : MonoBehaviour
{
    [SerializeField] float speed;
    Vector2 originalPosition;

    private void Awake()
    {
        originalPosition = this.transform.localPosition;
        speed = Random.Range(90f, 120f);
    }
    private void Update()
    {
        Debug.Log(originalPosition);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
       MoveToOrigin();
    }

    void MoveToOrigin()
    {
        if (transform.localPosition.x >= 7)
        {
            transform.localPosition = originalPosition;
            speed = Random.Range(90f, 120f);
        }
    }
}
