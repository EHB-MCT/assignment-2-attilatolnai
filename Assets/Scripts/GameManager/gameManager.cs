using System.Linq;
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

    public TextMeshProUGUI topPlayersDataText;

    //Data values
    public int circleCount;
    public int triangleCount;
    public int starCount;
    public float timeSpent;
    public float formattedTime;
    public bool isGameRunning;
    public string playerName;

    // Reference to other scripts
    public circleItem ci;
    public triangleItem ti;
    public starItem si;
    public timeTracker tt;
    public sendPlayerData spd;
    public UIManager uim;
    public ScoreCalculator sc;
    public Leaderboard lb;

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


        if (uim != null)
        {

            uim.OnGameStart += OnGameStart;
        }
        else
        {
            Debug.LogError("UIManager not assigned in gameManager!");
        }
    }

    void OnGameStart()
    {   
        if (tt != null)
        {
            tt.ResetTime();
            tt.StartTimer();
            tt.StartCountdown();
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

                if (firebaseInitialized && lb != null)
                {
                    lb.Initialize(databaseReference);
                    Debug.Log("Leaderboard initialized successfully!");
                }
                else
                {
                    Debug.LogError("Leaderboard script is not assigned or Firebase is not initialized.");
                }

            } 
            else 
            {
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

        int totalPoints = sc.GetTotalPoints();

        if (tt != null)
        {
            tt.StopTimer();
            //timeSpentText.text = "Time spent: " + Mathf.FloorToInt(tt.timeSpent) + " seconds";
            if (timeSpentText != null)
            {
                timeSpentText.text = "Time Spent: " + tt.formattedTime;
            }
        }

        sendPlayerData spd = FindObjectOfType<sendPlayerData>();
        if (spd != null)
        {
            spd.SubmitPlayerData(
                uim.playerName, 
                ci.circleCount, 
                ti.triangleCount, 
                si.starCount, 
                tt.formattedTime, 
                totalPoints
            );
        }

        FetchPreviousTwoGames(uim.playerName);
        
        circleCount = ci.circleCount;
        triangleCount = ti.triangleCount;
        starCount = si.starCount;

        displayPlayerName.text = "Player name: " + uim.playerName;
        circlesCollectedText.text = "Circles collected: " + circleCount.ToString();
        trianglesCollectedText.text = "Triangles collected: " + triangleCount.ToString();
        starsCollectedText.text = "Stars collected: " + starCount.ToString();
        totalScoreText.text = "Total points: " + totalPoints.ToString();

        Time.timeScale = 0f;        
        
        DisplayTopPlayers();
    }

    public void FetchPreviousTwoGames(string playerName)
    {
        if (databaseReference == null)
        {
            Debug.LogError("Firebase database reference is not initialized!");
            return;
        }

        databaseReference.Child("scores").OrderByChild("playerName").EqualTo(playerName).GetValueAsync().ContinueWithOnMainThread(task =>
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
                    Debug.Log("Data fetched from Firebase!"); // Check if data is being fetched
                    string stats = playerName + "'s previous 2 runs:\n";
                    
                    List<(string playerNameFromDB, string circles, string triangles, string stars, string timeSpent, string totalPoints, string timestamp)> gameData = new List<(string, string, string, string, string, string, string)>();
                    
                    foreach (var child in snapshot.Children)
                    {
                        string playerNameFromDB = child.Child("playerName").Value?.ToString();
                        string circles = child.Child("circleCount").Value?.ToString();
                        string triangles = child.Child("triangleCount").Value?.ToString();
                        string stars = child.Child("starCount").Value?.ToString();
                        string timeSpent = child.Child("timeSpent").Value?.ToString();
                        string totalPoints = child.Child("totalPoints").Value?.ToString();
                        string timestamp = child.Child("timestamp").Value?.ToString();

                        if (!string.IsNullOrEmpty(circles) && !string.IsNullOrEmpty(triangles) && 
                        !string.IsNullOrEmpty(stars) && !string.IsNullOrEmpty(timeSpent) && 
                        !string.IsNullOrEmpty(totalPoints) && !string.IsNullOrEmpty(timestamp))
                        {
                            gameData.Add((playerNameFromDB, 
                            circles, 
                            triangles, 
                            stars, 
                            timeSpent, 
                            totalPoints, 
                            timestamp));
                        }
                    }

                    var sortedGames = gameData.OrderByDescending(game => game.timestamp).Take(2).ToList();

                    if (sortedGames.Any())
                    {
                        foreach (var game in sortedGames)
                        {
                            stats += $"Player: {game.playerNameFromDB}\n" +
                                $"Circles: {game.circles},\n" +
                                $"Triangles: {game.triangles},\n" +
                                $"Stars: {game.stars},\n" +
                                $"Time: {game.timeSpent},\n" + 
                                $"Points: {game.totalPoints}\n" +
                                $"Timestamp: {game.timestamp}\n" +
                                "\n";
                        }

                        Debug.Log("Stats: " + stats); // Check the full stats output
                        previousPlayerDataText.text = stats;
                    }
                    else
                    {
                        Debug.LogWarning("No valid data found for this player.");
                        previousPlayerDataText.text = "No complete previous games found.";
                    }
                }
                else
                {
                    Debug.LogWarning("No data found in Firebase.");
                    previousPlayerDataText.text = "No previous games found.";
                }
            }
        });
    }
    

    public void DisplayTopPlayers()
    {
        if (lb != null)
        {
            lb.FetchTopPlayers();
        }
        else
        {
            Debug.LogError("Leaderboard script is not assigned in gameManager!");
        }
    }
}

