using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeTracker : MonoBehaviour
{
    public float timeSpent; // Tracks the time spent in the game
    public bool isGameRunning = true; // Indicates whether the game is active

    void Update()
    {
        if (isGameRunning)
        {
            timeSpent += Time.deltaTime; // Accumulate time while the game is running
        }
    }

    public void ResetTime()
    {
        timeSpent = 0f; // Reset the timer when restarting the game
    }

    public void StopTimer()
    {
        isGameRunning = false; // Stop the timer when the game ends
    }

    public void StartTimer()
    {
        isGameRunning = true; // Start the timer when the game begins
    }
}
