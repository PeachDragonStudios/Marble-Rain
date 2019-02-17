using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//New Script should be created in place of this one to include all special marbles
[RequireComponent(typeof(Rigidbody2D))]
public class SpecialMarbleScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.parent.CompareTag("Goal"))
        {
            if (gameObject.tag == "Shadow") //Script for Shadow Marbles
            {
                LivesManager.instance.LoseLife();
                ScoreManager.instance.ResetMultiplier();
            }
            else if (gameObject.tag == "Rush" || gameObject.tag == "PaletteSwap")
            {
                //do nothing
            }
            else //Script for Gold Marbles
            {
                ScoreManager.instance.AddPoints(10);
                ScoreManager.instance.DecrementGoldMod();
            }

            GameManager.instance.spawnedSpecialMarbles.Remove(this);
            Destroy(gameObject);
        }
    }

}
