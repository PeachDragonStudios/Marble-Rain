using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rushEffect : MonoBehaviour {

    public GameObject rushLetters;

    public GameManager gameManager;
    //gameManager = GetComponent<GameManager>();

    //private float time;

	// Use this for initialization
	void Start () {

        Debug.Log("The time is");

        Instantiate(rushLetters);

        
        if(Time.time < 25)
        {
            gameManager.SpawnMarble();
            gameManager.SpawnMarble();
        }
        else if(Time.time >= 25 && Time.time <= 50)
        {
            gameManager.SpawnMarble();
            gameManager.SpawnMarble();
            gameManager.SpawnMarble();
        }
        else if(Time.time > 50 && Time.time <= 85)
        {
            gameManager.SpawnMarble();
            gameManager.SpawnMarble();
            gameManager.SpawnMarble();
            gameManager.SpawnMarble();
        }
        else
        {
            gameManager.SpawnMarble();
            gameManager.SpawnMarble();
            gameManager.SpawnMarble();
            gameManager.SpawnMarble();
            gameManager.SpawnMarble();
        }
	}

    void Update()
    {
        //time = GameManager.GetCurrentTime();
    }

}
