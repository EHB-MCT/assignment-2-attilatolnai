using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timeTracker : MonoBehaviour
{
    public float timeSpent; // Tracks the time spent in the game
    public bool isGameRunning = true; // Indicates whether the game is active
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI timeUpText;

    public float countdownTime = 60f;
    private bool isCountdownRunning = false;

    public gameManager gm;

    void Start()
    {
        timeUpText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isGameRunning)
        {
            timeSpent += Time.deltaTime; // Accumulate time while the game is running
            UpdateTimerDisplay();
        }

        if (isCountdownRunning)
        {
            countdownTime -= Time.deltaTime;
            UpdateCountdownDisplay();

            if (countdownTime <= 0)
            {
                countdownTime = 0f;
                timeUpText.gameObject.SetActive(true);
                StopCountdown();
                EndGame();
            }
        }
    }

    //Reset time
    public void ResetTime()
    {
        timeSpent = 0f; // Reset the timer when restarting the game
        UpdateTimerDisplay();
    }

    //Countdown
    public void StartCountdown()
    {
        countdownTime = 60f; // Reset countdown to 1 minute
        isCountdownRunning = true; // Start the countdown
        timeUpText.gameObject.SetActive(false); // Ensure "Time is up" is hidden at the start
    }

    public void StopCountdown()
    {
        isCountdownRunning = false; // Stop the countdown
    }

    private void UpdateCountdownDisplay()
    {
        if (countdownTime <= 0) return;

        int minutes = Mathf.FloorToInt(countdownTime / 60);
        int seconds = Mathf.FloorToInt(countdownTime % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //Timer
    public void StopTimer()
    {
        isGameRunning = false; // Stop the timer when the game ends
    }

    public void StartTimer()
    {
        isGameRunning = true; // Start the timer when the game begins
    }

    public void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeSpent / 60);
        int seconds = Mathf.FloorToInt(timeSpent % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //Formatting
    public string formattedTime
    {
        get
        {
            int minutes = Mathf.FloorToInt(timeSpent / 60);
            int seconds = Mathf.FloorToInt(timeSpent % 60);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void EndGame()
    {
        if (gm != null)
        {
            gm.GameOver();
        }
    }

}
