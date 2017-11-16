using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleController : MonoBehaviour {

    private float distance = 10f;
    private Rigidbody2D rb;
    private Vector2 ZeroVelocity = new Vector2(0f, 0f);

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objPosition;        
    }

    void OnMouseUpAsButton()
    {
        rb.velocity = ZeroVelocity;
    }
}
