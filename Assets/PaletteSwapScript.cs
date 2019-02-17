using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteSwapScript : MonoBehaviour {

    //public GameObject[] marbles;
    //public GameObject[] Reds;
    //public GameObject[] arrows;

    public int swap = 0;
    public SpriteRenderer render;

    GameObject hold;

    // Use this for initialization
    void Start () {

        if (swap == 0) swap = 1;
        else swap = 0;





        //Testing grounds below \/

        //Reds = GameObject.FindGameObjectsWithTag("Red");

        //marbles = GameObject.FindObjectsOfType<Marble>;

        //foreach(GameObject red in Reds)
        //{
        //    //red.GetComponent<SpriteSwap>();

            

        //    //render = red.GetComponent<SpriteRenderer>();

        //    //if(red.name == "Red Goal")
        //    //{

        //    //    if(swap == 0)
        //    //    {
                    
        //    //    }
        //    //}
        //    //else if(red.name == "Red Arrow")
        //    //{

        //    //}

        //}
        
		
	}
	
}
