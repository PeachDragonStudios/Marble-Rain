using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rushEffect : MonoBehaviour {

    public GameObject rushLetters;

    //Not elegant but this is what keeps track of the spawning for rush
    private int count = 0;

	// Use this for initialization
	void Start () {

        Instantiate(rushLetters);

        Destroy(gameObject, 4);

    }

    void FixedUpdate()
    {
        if (GameManager.instance.timer < 25)
        {
            if(count == 39)
            {
                GameManager.instance.SpawnMarble();
                count = 0;
            }
            else
            {
                count++;
            }
            
        }
        else if (GameManager.instance.timer >= 25 && GameManager.instance.timer <= 50)
        {
            if (count == 52)
            {
                GameManager.instance.SpawnMarble();
                count = 0;
            }
            else
            {
                count++;
            }
        }
        else if (GameManager.instance.timer > 50 && GameManager.instance.timer <= 85)
        {
            if (count == 39)
            {
                GameManager.instance.SpawnMarble();
                count = 0;
            }
            else
            {
                count++;
            }
        }
        else
        {
            if (count == 31)
            {
                GameManager.instance.SpawnMarble();
                count = 0;
            }
            else
            {
                count++;
            }
        }
    }
}
