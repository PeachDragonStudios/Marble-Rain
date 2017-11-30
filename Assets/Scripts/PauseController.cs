using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    // Is the game paused or not?
    [HideInInspector] public bool isPaused = false;

    private GameObject pauseScreen;
    
    /*
     * The pause screen is hidden on game start
     */
    void Awake()
    {
        pauseScreen = GameObject.Find("Pause Screen");
        pauseScreen.SetActive(false);
    }

    /*
     * The method used when the pause button is pressed on the game screen
     */
    public void OnPauseButton()
    {
        // If the game isn't paused, set isPaused to true, stop game time, and show the pause screen
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
    }

    /*
     * The method used when the play button is pressed on the pause screen
     */
    public void OnPlayButton()
    {
        // If the game is paused, set isPaused to false, game time is normalized, and hide the pause screen again
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);   
        }
    }
}
