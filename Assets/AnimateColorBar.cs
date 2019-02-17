using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateColorBar : MonoBehaviour {

    public GameObject colorBar;

    Vector3 spawnLocation = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {

        GameObject SpawnedColorBar = Instantiate(colorBar, spawnLocation, Quaternion.identity);

	}
	
}
