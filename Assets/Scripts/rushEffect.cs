using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rushEffect : MonoBehaviour {

    private IEnumerator coroutine;

    public GameObject rushLetters;

	// Use this for initialization
	void Start () {

        //TimeDelay not currently working, probably because waitForSeconds
        //Doesn't immediately take action, might need to add loop to make sure time delay happens.

        //coroutine = TimeDelay(2.0f);

        Instantiate(rushLetters);

        if (GameManager.instance.timer < 25)
        {
            GameManager.instance.SpawnMarble();
            //StartCoroutine(coroutine);
            TimeDelay(3);
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
        }
        else if (GameManager.instance.timer >= 25 && GameManager.instance.timer <= 50)
        {
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
        }
        else if (GameManager.instance.timer > 50 && GameManager.instance.timer <= 85)
        {
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
        }
        else
        {
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
            GameManager.instance.SpawnMarble();
            TimeDelay(3);
        }

    }

    private IEnumerator TimeDelay(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(waitTime);
        }
    }

}
