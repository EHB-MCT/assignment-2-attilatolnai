using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Firebase.Database;
using Firebase.Extensions;

public class gameManager : MonoBehaviour
{
    //Firebase
    private Firebase.FirebaseApp app;
    private DatabaseReference databaseReference;

    //GameOver UI Panel
    public GameObject gameOverMenu;

    //Text elements inside the game over screen
    public TextMeshProUGUI circlesCollectedText;
    public TextMeshProUGUI timeSpentText;
    public TextMeshProUGUI previousPlayerDataText;

    //Data values
    public int circleCount;
    public float timeSpent;
    public bool isGameRunning;

    //Executed when the project starts
    void Start()
    {
        gameOverMenu.SetActive(false);
        InitializeFirebase();
        
    }

    //Initializes Firebase
    private void InitializeFirebase()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                app = Firebase.FirebaseApp.DefaultInstance;
                databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
                Debug.Log("Firebase initialized successfully!");

            } else {
                UnityEngine.Debug.LogError(System.String.Format(
                "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });
    }

    //When the player gets a game over
    public void GameOver()
    {
        isGameRunning = false;

        gameOverMenu.SetActive(true);

        FetchPreviousPlayerData();

        circlesCollectedText.text = "Circles collected: " + circleCount.ToString();
        timeSpentText.text = "Time spent: " + Mathf.FloorToInt(timeSpent) + " seconds";

        Time.timeScale = 0f;
    }

    //Send player data to the database
    public void SubmitPlayerData(string playerName, int circleCount, float timeSpent)
    {
        if(databaseReference == null)
        {
            Debug.LogError("Firebase not initialized");
            return;
        }

        //Add an entry under "scores" in the database
        string key = databaseReference.Child("scores").Push().Key;
        var entryData = new Dictionary<string, object>
        {
            { "playerName", playerName },
            { "circleCount", circleCount },
            { "timeSpent", timeSpent }
        };

        databaseReference.Child("scores").Child(key).SetValueAsync(entryData).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("Data submitted successfully!");
            }
            else
            {
                Debug.LogError($"Error submitting data: {task.Exception}");
            }
        });
    }

    //Get data from the previous player
    public void FetchPreviousPlayerData()
    {
        if (databaseReference == null)
        {
            Debug.LogError("Firebase database reference is not initialized!");
            return;
        }

        // Fetch the last entry under 'scores'.
        databaseReference.Child("scores").OrderByKey().LimitToLast(1).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("Error fetching data: " + task.Exception);
                previousPlayerDataText.text = "Error fetching data.";
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                if (snapshot.Exists)
                {
                    foreach (var child in snapshot.Children)
                    {
                        string playerName = child.Child("playerName").Value?.ToString();
                        string circleCount = child.Child("circleCount").Value?.ToString();
                        string timeSpent = child.Child("timeSpent").Value?.ToString();

                        // Update the UI text with the fetched data.
                        previousPlayerDataText.text = $"Last Player: {playerName}\n" +
                                                      $"Circles Collected: {circleCount}\n" +
                                                      $"Time Spent: {timeSpent} seconds";
                        Debug.Log("Previous player data updated successfully.");
                    }
                }
                else
                {
                    Debug.LogWarning("No data found in the database.");
                    previousPlayerDataText.text = "No previous player data found.";
                }
            }
        });
    }
}

