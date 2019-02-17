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
    private Text highScoreText;
    public static int highScore;

    // Timer variables
    public float timer;
    private int minutes;
    private int seconds;
    private Text timerText;

    //PaletteSwap variable
    public int swap = 0;

    // Marble variables
    private float[] xDropPositions = new float[] { -1.18f, -3.41f, 1.1f, 3.35f };
    public float originalGravityScale;
    public Marble[] marblePrefabs;
    [HideInInspector] public List<Marble> spawnedMarbles;

    public SpecialMarbleScript[] specialMarblePrefabs;
    [HideInInspector] public List<SpecialMarbleScript> spawnedSpecialMarbles;


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

        // Before the game is loaded, the game time should not start
        Time.timeScale = 0f;
    }

    #endregion

    /*
     * Used to initialize the game and its components
     */
    void InitGame()
    {
        // Get all text components
        timerText = GameObject.Find("Timer Text").GetComponent<Text>();
        gameOverScreen = GameObject.Find("Game Over Screen");
        gameOverScoreText = GameObject.Find("Game Over Score").GetComponent<Text>();
        highScoreText = GameObject.Find("High Score Text").GetComponent<Text>();
        gameOverScreen.SetActive(false);

        ScoreManager.instance.ResetScore();  // Reset score

        // Reset all time variables
        frameCount = 0;
        timer = 0f;
        minutes = (int)timer / 60;
        seconds = (int)timer % 60;
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        //Reset PalatteSwap variable
        swap = 0;

        // Reset the number of lives
        LivesManager.instance.ResetLives();

        // Begin the game by bringing time scale up to 1f
        Time.timeScale = 1f;


        AutoSpawnSpecialMarbles();

        //Special Marble Spawn
        //Script may not be properly restarting when player hits play again.
        //May need spawning method similar to one used for regular marbles
        //InvokeRepeating("SpawnSpecialMarble", 12f, 15f);
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

    /*
     * Fixed update is called 50 times in a second at a fixed rate
     */
    void FixedUpdate()
    {
        // Count up the timer consistently
        CountUpTimer();

        // Spawn marbles consistently
        AutoSpawnMarble();
    }

    /*
     * Used to calculate the game timer
     */
    private void CountUpTimer()
    {
        timer += Time.deltaTime;

        minutes = (int)timer / 60;
        seconds = (int)timer % 60;

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public float GetCurrentTime()
    {
        return timer;
    }

    #region Marble Spawning

    /*
     * Spawns a random marble at a random location
     */
    public void SpawnMarble()
    {
        
        int randomLane = Random.Range(0, xDropPositions.Length); // Choose a drop position out of a list
        Vector3 dropPosition = new Vector3(xDropPositions[randomLane], 5.8f, 0f); // Sets the drop position at a lane and a set height on the board

        int randomMarble = Random.Range(0, marblePrefabs.Length); // Choose a random marble out of a list

        Marble newMarble = Instantiate(marblePrefabs[randomMarble], dropPosition, Quaternion.identity); // Spawn a new marble on the board
        spawnedMarbles.Add(newMarble); // Add the new spawned marble to a list of current marbles on the board
        newMarble.GetComponent<Rigidbody2D>().gravityScale = originalGravityScale; // Ensure that the marble has a set gravity scale
    }

    //New for special marble
    //should be later edited along with SpecialMarbleScript.cs to spawn heart and shadow special Marbles
    public void SpawnSpecialMarble()
    {
        int randomLane = Random.Range(0, xDropPositions.Length); //Uses same drop positions as SpawnMarble
        Vector3 dropPosition = new Vector3(xDropPositions[randomLane], 5.8f, 0f); //Same drop positioning as Spawn Marble

        //int randomSpecialMarble = Random.Range(0, specialMarblePrefabs.Length);

        //Script for testing specific special marbles
        int randomSpecialMarble = 3;

        SpecialMarbleScript newSpecialMarble = Instantiate(specialMarblePrefabs[randomSpecialMarble], dropPosition, Quaternion.identity);

        //Gold marble score increment
        if(newSpecialMarble.tag == "Gold")
        {
            ScoreManager.instance.IncrementGoldMod();
        }

        if(newSpecialMarble.tag == "PaletteSwap")
        {
            if (swap == 0) swap = 1;
            else swap = 0;
        }
        
        spawnedSpecialMarbles.Add(newSpecialMarble); // Add the new spawned marble to a list of current marbles on the board
        newSpecialMarble.GetComponent<Rigidbody2D>().gravityScale = originalGravityScale; // Ensure that the marble has a set gravity scale
    }
    //end new code for special marble
    

    /*
     * Will spawn a marble based on time passed and the count of the method called
     */
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

    private void AutoSpawnSpecialMarbles()
    {
        InvokeRepeating("SpawnSpecialMarble", 12f, 15f);
        Debug.Log("Spawn special marble");
    }
    #endregion

    /*
     * Display the game over screen after lives run out
     */
    public void DisplayGameOver()
    {
        CancelInvoke();

        if(highScore < ScoreManager.instance.totalPoints)
        {
            highScore = (int)ScoreManager.instance.totalPoints;

            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();
        }

        highScoreText.text = "" + PlayerPrefs.GetInt("highScore");

        gameOverScoreText.text = "Your Score: " + ScoreManager.instance.totalPoints;

        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }    
}
