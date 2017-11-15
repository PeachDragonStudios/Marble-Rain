using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour {

    [HideInInspector] public bool isPaused = false;

    private GameObject pauseScreen;

    void Awake()
    {
        pauseScreen = GameObject.Find("Pause Screen");
        pauseScreen.SetActive(false);
    }

    public void OnPauseButton()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
    }

    public void OnPlayButton()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);   
        }
    }
}
