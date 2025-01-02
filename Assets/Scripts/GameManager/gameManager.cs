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
    public DatabaseReference _databaseReference;
    public bool firebaseInitialized = false;

    //GameOver UI Panel
    public GameObject gameOverMenu;

    //Text elements inside the game over screen
    public TMP_InputField playerNameInput;

    public TextMeshProUGUI circlesCollectedText;
    public TextMeshProUGUI circlePointsUI;

    public TextMeshProUGUI trianglesCollectedText;
    public TextMeshProUGUI trianglePointsUI;

    public TextMeshProUGUI starsCollectedText;
    public TextMeshProUGUI starPointsUI;

    public TextMeshProUGUI timeSpentText;
    public TextMeshProUGUI previousPlayerDataText;
    public TextMeshProUGUI displayPlayerName;
    public TextMeshProUGUI totalScoreText;
    public Button sendButton;

    //Data values
    public int circleCount;
    public int triangleCount;
    public int starCount;
    public float timeSpent;
    public bool isGameRunning;
    public string playerName;

    // Reference to other scripts
    public circleItem ci;
    public triangleItem ti;
    public starItem si;
    public timeTracker tt;
    public sendPlayerData spd;
    public UIManager uim;
    //public ScoreCalculator sc;

    public DatabaseReference databaseReference
    {
        get {return _databaseReference; }
        set {_databaseReference = value; }
    }

    //Executed when the project starts
    void Start()
    {
        gameOverMenu.SetActive(false);
        InitializeFirebase();

        if (tt != null)
        {
            tt.ResetTime();
            tt.StartTimer();
        }
        if (sendButton != null)
        {
            sendButton.onClick.AddListener(OnSendButtonClicked);
        }
        if (uim != null)
        {
            playerName = uim.playerName;
            Debug.Log("Player Name: " + playerName);
        }
        else
        {
            Debug.LogError("UIManager not assigned in gameManager!");
        }
        
    }

    private void OnSendButtonClicked()
    {
        if (spd != null)
        {
            string playerName = "Player"; // Or retrieve the player name from the input field
            spd.SubmitPlayerData(playerName, circleCount, triangleCount, starCount, timeSpent);
        }
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
                firebaseInitialized = true;
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

        if (tt != null)
        {
            tt.StopTimer();
            timeSpentText.text = "Time spent: " + Mathf.FloorToInt(tt.timeSpent) + " seconds";
        }

        sendPlayerData spd = FindObjectOfType<sendPlayerData>();
        if (spd != null)
        {
            spd.SubmitPlayerData(uim.playerName, ci.circleCount, ti.triangleCount, si.starCount, tt.timeSpent);
        }

        FetchPreviousPlayerData();

        circleCount = ci.circleCount;
        triangleCount = ti.triangleCount;
        starCount = si.starCount;

        displayPlayerName.text = "Player name: " + uim.playerName;
        circlesCollectedText.text = "Circles collected: " + circleCount.ToString();
        trianglesCollectedText.text = "Triangles collected: " + triangleCount.ToString();
        starsCollectedText.text = "Stars collected: " + starCount.ToString();

        Time.timeScale = 0f;
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
                        string triangleCount = child.Child("triangleCount").Value?.ToString();
                        string starCount = child.Child("starCount").Value?.ToString();
                        string timeSpent = child.Child("timeSpent").Value?.ToString();

                        // Update the UI text with the fetched data.
                        previousPlayerDataText.text = "From the database:\n" +
                                                      $"Last Player: {playerName}\n" +
                                                      $"Circles Collected: {circleCount}\n" +
                                                      $"Triangles Collected: {triangleCount}\n" +
                                                      $"Stars Collected: {starCount}\n" +
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

