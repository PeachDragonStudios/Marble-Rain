using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Marble : MonoBehaviour {
    
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent.CompareTag("Goal"))
        {
            if (collision.gameObject.tag == tag)
            {
                //Debug.Log("These two objects were the same color");
                GameManager.instance.AddPoints(100);
            }

            Destroy(this.gameObject);
        }
    }
}
