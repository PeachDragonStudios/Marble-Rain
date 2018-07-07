using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShadowFade : MonoBehaviour {

    private float lifeTime = 5f;
    private GameObject SM;

    //updates 40 times per second
    public void Awake()
    {
        SM = GameObject.FindGameObjectWithTag("Shadow");
        Destroy(SM, lifeTime);
    }
}
