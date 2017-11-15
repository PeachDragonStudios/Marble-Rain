using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MarbleController : MonoBehaviour {

    public float timeStop = 3f;

    private Rigidbody2D rb;

    private float distance = 10f;
    private float stopTime;
    private float originalGravityScale;
    private Vector2 ZeroVelocity = new Vector2(0f, 0f);
    private bool isTimeStopped = false;

    private List<Marble> marbles;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
    }

    void Update()
    {
        if (isTimeStopped && Time.time - stopTime >= timeStop)
        {
            rb.gravityScale = originalGravityScale;
            rb.velocity = ZeroVelocity;

            isTimeStopped = false;
        }
    }

    public void OnStasisButton()
    {
        rb.gravityScale = 0f;
        rb.velocity = ZeroVelocity;

        stopTime = Time.time;
        isTimeStopped = true;

        Debug.Log(stopTime);
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
