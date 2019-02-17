using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwap : MonoBehaviour {

    public Sprite spriteMain;
    public Sprite spriteAlt;

    private SpriteRenderer spriteRender;

    //PaletteSwapScript Pswap = PaletteSwap.GetComponent<PaletteSwapScript>();

	// Use this for initialization
	void Start () {

        spriteRender = GetComponent<SpriteRenderer>();
        if (spriteRender.sprite == null)
        {
            spriteRender.sprite = spriteMain;
        }

    }

    void Update()
    {
        ChangeSprite();
    }

    public void ChangeSprite()
    {
        if (GameManager.instance.swap == 1)
        {
            spriteRender.sprite = spriteAlt;
        }
        else
        {
            spriteRender.sprite = spriteMain;
        }

        //if (spriteRender.sprite == spriteMain)
        //{
        //    spriteRender.sprite = spriteAlt;
        //}
        //else
        //{
        //    spriteRender.sprite = spriteMain;
        //}

    }
}
