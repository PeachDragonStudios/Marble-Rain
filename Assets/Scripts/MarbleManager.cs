using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleManager : MonoBehaviour {

    public float timeStop = 3f;
    //public float originalGravityScale;

    private float stopTime;
    private Vector2 ZeroVelocity = new Vector2(0f, 0f);
    private bool isTimeStopped = false;

    void Update()
    {
        if (isTimeStopped && Time.time - stopTime >= timeStop)
        {
            foreach (Marble marble in GameManager.instance.spawnedMarbles)
            {
                Rigidbody2D rb = marble.GetComponent<Rigidbody2D>();

                rb.gravityScale = GameManager.instance.originalGravityScale;
                rb.velocity = ZeroVelocity;
            }

            isTimeStopped = false;
        }
    }

    public void OnStasisButton()
    {
        foreach (Marble marble in GameManager.instance.spawnedMarbles)
        {
            Rigidbody2D rb = marble.GetComponent<Rigidbody2D>();

            rb.gravityScale = 0f;
            rb.velocity = ZeroVelocity;
        }

        stopTime = Time.time;
        isTimeStopped = true;

        Debug.Log(stopTime);
    }
}
