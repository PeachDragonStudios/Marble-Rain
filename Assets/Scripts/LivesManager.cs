using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesManager : MonoBehaviour {

    public Sprite[] livesImages;
    public Image currentLivesImage;

    private int playerLives = 4;

    #region Singleton

    public static LivesManager instance;

    void Awake()
    {
        instance = this;

        currentLivesImage = GameObject.Find("Lives").GetComponent<Image>();
    }

    #endregion

    public void LoseLife()
    {
        if (playerLives > 0)
        {
            playerLives--;
        }

        if (playerLives == 0)
        {
            GameManager.instance.DisplayGameOver();
        }
        else
        {
            UpdateLivesImage();
        }
        
    }

    public void AddLife()
    {
        if (playerLives < 4)
        {
            playerLives++;
        }

        UpdateLivesImage();
    }

    void UpdateLivesImage()
    {
        currentLivesImage.sprite = livesImages[playerLives - 1];
    }

    public void ResetLives() 
    {
        playerLives = 4;
        UpdateLivesImage();
    }
}
