using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marble : MonoBehaviour {


    private Rigidbody2D rb;
    public string tagColor;

    void Awake()
    {
        tagColor = this.gameObject.tag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent.CompareTag("Goal"))
        {
            if (collision.gameObject.tag == tagColor)
            {
                //Debug.Log("These two objects were the same color");
                GameManager.instance.AddPoints(100);
            }

            Destroy(this.gameObject);
        }
    }
}
