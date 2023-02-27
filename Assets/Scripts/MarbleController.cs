using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleController : MonoBehaviour {

    private float distance = 10f;
    private Rigidbody2D rb;
    private Vector2 ZeroVelocity = new Vector2(0f, 0f);

    //vatiables for Nearestx method
    private float[] GuideLines = new float[] { -3.41f, -1.18f, 1.1f, 3.35f }; //little bit redundant to xDropPositions
    private float bestx;
    private float compareResult;

    //variables for OnMouseUpAsButton marble transtion
    private float marbleTransSpeed = 3f;
    private Vector2 goalPosition;

    //For off screen positioning
    private float leftEdge = 0.0f;
    private float rightEdge = 0.0f;
    public float buffer = 1.0f;
    public float CamDistz = -10.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, CamDistz)).x;
        rightEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, CamDistz)).x;

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

        //Debug.Log(transform.position);

        //code to hopefully gradually transtion the marble into place


        if (transform.position.x < leftEdge + buffer)
        {
            goalPosition = new Vector2(GuideLines[0], transform.position.y);
            transform.position = goalPosition;
        }
        else if (transform.position.x > rightEdge + buffer)
        {
            goalPosition = new Vector2(GuideLines[3], transform.position.y);
            transform.position = goalPosition;
        }
        else
        {
            Nearestx(transform.position.x);
            goalPosition = new Vector2(bestx, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, goalPosition, marbleTransSpeed);
        }

        
        
    }

    //calculate which Guideline is closest via its relative distance from the obj
    private void Nearestx(float x)
    {
        bestx = GuideLines[0];
        compareResult = Mathf.Abs(x - GuideLines[0]);

        if (transform.position.x < leftEdge + buffer) bestx = GuideLines[0];
        else if (transform.position.x > rightEdge + buffer) bestx = GuideLines[3];
        else
        {
            for (int i = 1; i < GuideLines.Length; i++)
            {
                if (Mathf.Abs(x - GuideLines[i]) < compareResult)
                {
                    compareResult = Mathf.Abs(x - GuideLines[i]);
                    bestx = GuideLines[i];
                }

            }
        }      
    }
}
