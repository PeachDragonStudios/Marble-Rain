using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    // Score variables
    public double totalPoints;
    public double multiplier;
    private Text scoreText;

    #region Singleton

    public static ScoreManager instance;

    void Awake()
    {
        instance = this;

        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
    }

    #endregion

    // Adds points to the player's score
    public void AddPoints(int points)
    {
        totalPoints += ((double)points * multiplier);

        scoreText.text = "Score: " + totalPoints.ToString();

        if (multiplier < 2)
        {
            IncrementMultiplier();
        }
    }

    public void IncrementMultiplier()
    {
        multiplier += 0.1;
    }

    public void ResetMultiplier()
    {
        multiplier = 1.0;
    }

    public void ResetScore()
    {
        totalPoints = 0.0;
        multiplier = 1.0;
    }
}
