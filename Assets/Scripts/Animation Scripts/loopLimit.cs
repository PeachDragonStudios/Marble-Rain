using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopLimit : MonoBehaviour {

    public int loopNum = 3;

    // Use this for initialization
    void Start () {

        Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length * loopNum);
		
	}
}
