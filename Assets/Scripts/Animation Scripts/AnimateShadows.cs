using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateShadows : MonoBehaviour {

    public GameObject[] shadows;

    int shadowToSpawn;

    float RandomPositionY, RandomPositionX;
    Vector3 spawnLocation;

    // Use this for initialization
    void Start () {
        InvokeRepeating("spawnShadow", 0.05f, 0.2f);
		
	}

    void spawnShadow()
    {
        shadowToSpawn = Random.Range(0, 2);

        RandomPositionY = Random.Range(this.gameObject.transform.position.y - 1, this.gameObject.transform.position.y + 1);
        RandomPositionX = Random.Range(this.gameObject.transform.position.x - 1, this.gameObject.transform.position.x + 1);
        spawnLocation = new Vector3(RandomPositionX, RandomPositionY, 0);

        GameObject shadow = Instantiate(shadows[shadowToSpawn], spawnLocation, Quaternion.identity);
    }
	
}
