using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StasisScript : MonoBehaviour {

    public float timeStop = 3f; // Determines how long time is stopped in seconds

    private float stopTime;     // The time at which the stasis button was pressed
    private Vector2 ZeroVelocity = new Vector2(0f, 0f);     // A Vector2 to set the marbles to a velocity of 0
    public static bool isTimeStopped = false;       // Set to false when marbles ARE NOT in "stasis"; set to true when marbles ARE in "stasis"

    void Update()
    {
        // Check if time is stopped and if the time elapsed is greater than the stasis time
        if (isTimeStopped && Time.time - stopTime >= timeStop)
        {
            // For every marble on the board, set their Rigidbody2D gravity scale back to normal
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
        // For every marble on the board, set their Rigidbody2D gravity scale to 0
        foreach (Marble marble in GameManager.instance.spawnedMarbles)
        {
            Rigidbody2D rb = marble.GetComponent<Rigidbody2D>();

            rb.gravityScale = 0f;
            rb.velocity = ZeroVelocity;
        }

        // Record the game time when the button was pressed and set isTimeStopped to true
        stopTime = Time.time;
        isTimeStopped = true;

        // Debug.Log(stopTime);
    }
}
