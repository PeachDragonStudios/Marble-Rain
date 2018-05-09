using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShadowFade : MonoBehaviour {

    private float lifeTime = 4f;
    private GameObject SM;

    //code for spawning shadow blobs, needs to have location accessing
    /*
    public shadowBlobs[] shdwBlobs;
    [HideInInspector] public List<shadowBlobs> spawnedBlobs;
    */

    //updates 40 times per second
    public void Awake()
    {
        SM = GameObject.FindGameObjectWithTag("Shadow");
        Destroy(SM, lifeTime);
    }
}
