using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rushEffect : MonoBehaviour {

    public GameObject rushLetters;

	// Use this for initialization
	void Start () {

        Instantiate(rushLetters);

        if (GameManager.instance.timer < 25)
        {
            GameManager.instance.SpawnMarble();
            GameManager.instance.SpawnMarble();
        }
        else if (GameManager.instance.timer >= 25 && GameManager.instance.timer <= 50)
        {
            GameManager.instance.SpawnMarble();
            GameManager.instance.SpawnMarble();
            GameManager.instance.SpawnMarble();
        }
        else if (GameManager.instance.timer > 50 && GameManager.instance.timer <= 85)
        {
            GameManager.instance.SpawnMarble();
            GameManager.instance.SpawnMarble();
            GameManager.instance.SpawnMarble();
            GameManager.instance.SpawnMarble();
        }
        else
        {
            GameManager.instance.SpawnMarble();
            GameManager.instance.SpawnMarble();
            GameManager.instance.SpawnMarble();
            GameManager.instance.SpawnMarble();
            GameManager.instance.SpawnMarble();
        }

    }

}
