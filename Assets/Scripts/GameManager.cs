using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region Variables

    //AutoSpawn variables
    private int frameCount;

    // Score variables
    public int totalPoints = 0;
    public int multiplier = 1;
    private Text scoreText;

    // Timer variables
    public float timer = 0;
    private int minutes = 0;
    private int seconds = 0;
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
        scoreText = GameObject.Find("Score Text").GetComponent<Text>();
        timerText = GameObject.Find("Timer Text").GetComponent<Text>();

        minutes = (int)timer / 60;
        seconds = (int)timer % 60;
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

        //InvokeRepeating("SpawnMarble", 0f, 2f);
        frameCount = 0;

    }

    #endregion

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnMarble();
        }
        */

        CountUpTimer();
    }

     void FixedUpdate()
    {
        AutoSpawnMarble();
        

    }


    public void AddPoints(int points)
    {
        totalPoints += (points * multiplier);

        scoreText.text = "Score: " + totalPoints.ToString();
    }

    private void SpawnMarble()
    {
        int randomLane = Random.Range(0, xDropPositions.Length);
        Vector3 dropPosition = new Vector3(xDropPositions[randomLane], 5.8f, 0f);

        int randomMarble = Random.Range(0, marblePrefabs.Length);

        Marble newMarble = Instantiate(marblePrefabs[randomMarble], dropPosition, Quaternion.identity);
        spawnedMarbles.Add(newMarble);
        newMarble.GetComponent<Rigidbody2D>().gravityScale = originalGravityScale;
    } 

    private void CountUpTimer()
    {
        timer += Time.deltaTime;

        minutes = (int)timer / 60;
        seconds = (int)timer % 60;

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
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
}
