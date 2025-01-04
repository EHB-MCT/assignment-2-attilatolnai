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

    void Update()
    {
        if (isGameRunning)
        {
            timeSpent += Time.deltaTime; // Accumulate time while the game is running
            UpdateTimerDisplay();
        }
    }

    public void ResetTime()
    {
        timeSpent = 0f; // Reset the timer when restarting the game
        UpdateTimerDisplay();
    }

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

    public string formattedTime
    {
        get
        {
            int minutes = Mathf.FloorToInt(timeSpent / 60);
            int seconds = Mathf.FloorToInt(timeSpent % 60);
            return string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

}
