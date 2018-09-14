using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleController : MonoBehaviour {

    private float distance = 10f;
    private Rigidbody2D rb;
    private Vector2 ZeroVelocity = new Vector2(0f, 0f);

    //Touch variable
    private Vector3 touchPosition = new Vector3(0f, 0f, 10f);

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //Needs to check if a marble exist at the touch location (Maybe)
        Touch firstTouch = Input.GetTouch(0);
        //Touch secondTouch = Input.touches[1];

        //if(firstTouch.phase == TouchPhase.Began)
        //{
        //    TouchLocation = firstTouch.position; // might not be neccesary
        //    touchPosition.x = firstTouch.position.x;
        //    touchPosition.y = firstTouch.position.y;
        //    Vector3 objPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        //}
        if (firstTouch.phase == TouchPhase.Moved)
            {
                touchPosition.x = firstTouch.position.x;
                touchPosition.y = firstTouch.position.y;
                Vector3 objPosition = Camera.main.ScreenToWorldPoint(touchPosition);
                transform.position = objPosition;
            }
            else if(firstTouch.phase == TouchPhase.Ended)
            {
                rb.velocity = ZeroVelocity;
            }

            //if(secondTouch.phase == TouchPhase.Began)
            //{
            //    TouchStartTwo = secondTouch.position;
            //}
            
    }

    //Read into OnMouseDrag
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
    //void OnTouch()
    //{
    //    Touch touch = Input.GetTouch(0);
    //    Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, distance);
    //    Vector3 objPosition = Camera.main.ScreenToWorldPoint(touchPosition);
    //    transform.position = objPosition;

        
    //}
    //void OnTouchRelease()
    //{
    //    rb.velocity = ZeroVelocity
    //}
}
