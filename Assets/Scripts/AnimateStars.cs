using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateStars : MonoBehaviour {

    public GameObject GoldMarbleStars;

    float RandomPositionY, RandomPositionX;
    Vector3 spawnLocation;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnStar", 0.1f, 0.4f);
	}

    void SpawnStar()
    {
        RandomPositionY = Random.Range(this.gameObject.transform.position.y - 2, this.gameObject.transform.position.y + 2);
        RandomPositionX = Random.Range(this.gameObject.transform.position.x - 2, this.gameObject.transform.position.x + 2);
        spawnLocation = new Vector3(RandomPositionX, RandomPositionY, 0);

        GameObject goldStar = Instantiate(GoldMarbleStars, spawnLocation, Quaternion.identity);
    }
}
