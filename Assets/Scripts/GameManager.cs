using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    #region Variables

    public int totalPoints = 0;
    public int multiplier = 1;

    public float timer = 99f;
    private int minutes = 0;
    private int seconds = 0;

    private Text scoreText;
    private Text timerText;

    private float[] xDropPositions = new float[] { -1.18f, -3.41f, 1.1f, 3.35f };

    public Marble[] marbles;

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

        SpawnMarble();
    }

    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnMarble();
        }

        CountDownTimer();
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

        int randomMarble = Random.Range(0, marbles.Length);

        Instantiate(marbles[randomMarble], dropPosition, Quaternion.identity);
    } 

    private void CountDownTimer()
    {
        timer -= Time.deltaTime;

        minutes = (int)timer / 60;
        seconds = (int)timer % 60;

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
