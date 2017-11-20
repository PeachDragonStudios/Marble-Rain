using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region Variables

    //AutoSpawn variables
    private int frameCount = 0;

    private Text gameOverScoreText;
    private GameObject gameOverScreen;

    // Timer variables
    private float timer;
    private int minutes;
    private int seconds;
    private Text timerText;

    // Marble variables
    private float[] xDropPositions = new float[] { -1.18f, -3.41f, 1.1f, 3.35f };
    public float originalGravityScale;
    public Marble[] marblePrefabs;
    [HideInInspector] public List<Marble> spawnedMarbles;

    #endregion

    #region Singleton

    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Time.timeScale = 0f;
    }

    #endregion

    void InitGame()
    {
        // Get all text components
        timerText = GameObject.Find("Timer Text").GetComponent<Text>();
        gameOverScreen = GameObject.Find("Game Over Screen");
        gameOverScoreText = GameObject.Find("Game Over Score").GetComponent<Text>();
        gameOverScreen.SetActive(false);

        ScoreManager.instance.ResetScore();  // Reset score

        // Reset all time variables
        frameCount = 0;
        timer = 0f;
        minutes = (int)timer / 60;
        seconds = (int)timer % 60;
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        // Reset the number of lives
        LivesManager.instance.ResetLives();

        // Begin the game by bringing time scale up to 1f
        Time.timeScale = 1f;
    }

    #region Scene Management

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        // Call InitGame to initialize our level.
        InitGame();
    }

    void OnEnable()
    {
        // Tell our 'OnLevelFinishedLoading' function to start listening for a scene change event as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        // Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change event as soon as this script is disabled.
        // Remember to always have an unscubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    #endregion

    // Is called 50 times in a second at a fixed rate
    void FixedUpdate()
    {
        CountUpTimer();

        AutoSpawnMarble();
    }

    private void CountUpTimer()
    {
        timer += Time.deltaTime;

        minutes = (int)timer / 60;
        seconds = (int)timer % 60;

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    #region Marble Spawning

    // Spawns a random marble at a random location
    private void SpawnMarble()
    {
        int randomLane = Random.Range(0, xDropPositions.Length);
        Vector3 dropPosition = new Vector3(xDropPositions[randomLane], 5.8f, 0f);

        int randomMarble = Random.Range(0, marblePrefabs.Length);

        Marble newMarble = Instantiate(marblePrefabs[randomMarble], dropPosition, Quaternion.identity);
        spawnedMarbles.Add(newMarble);
        newMarble.GetComponent<Rigidbody2D>().gravityScale = originalGravityScale;
    }

    private void AutoSpawnMarble()
    {
        if (frameCount >= 110 && timer <= 15f)
        {
            SpawnMarble();
            frameCount = 0;
        }
        else if (frameCount >= 90 && timer > 15f && timer <= 30f)
        {
            SpawnMarble();
            frameCount = 0;
        }
        else if (frameCount >= 70 && timer > 30f && timer <= 60f)
        {
            SpawnMarble();
            frameCount = 0;
        }
        else if (frameCount >= 55 && timer > 60f && timer <= 90f)
        {
            SpawnMarble();
            frameCount = 0;
        }
        else if (frameCount >= 40 && timer > 90f && timer <= 130f)
        {
            SpawnMarble();
            frameCount = 0;
        }
        else if (frameCount >= 25 && timer > 130f)
        {
            SpawnMarble();
            frameCount = 0;
        }
        else frameCount++;
    }

    #endregion

    public void DisplayGameOver()
    {
        gameOverScoreText.text = "Your Score: " + ScoreManager.instance.totalPoints;

        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }    
}
