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
    public getPreviousTwoGames gptg;
    public compareToHighscore cth;

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

    public void GameOver()
    {
        isGameRunning = false;

        gameOverMenu.SetActive(true);

        int totalPoints = sc.GetTotalPoints();

        if (tt != null)
        {
            tt.StopTimer();
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

        if (gptg != null)
        {
            gptg.FetchPreviousTwoGames(uim.playerName);
        }
        else
        {
            Debug.LogError("getPreviousTwoGames script not found in the scene!");
        }

        if (cth != null)
        {
            cth.CompareToHighscore(uim.playerName);
        }
        else
        {
            Debug.LogError("compareToHighscore script not found in the scene!");
        }
        /*
        circleCount = ci.circleCount;
        triangleCount = ti.triangleCount;
        starCount = si.starCount;

        displayPlayerName.text = "Player name: " + uim.playerName;
        circlesCollectedText.text = "Circles collected: " + circleCount.ToString();
        trianglesCollectedText.text = "Triangles collected: " + triangleCount.ToString();
        starsCollectedText.text = "Stars collected: " + starCount.ToString();
        totalScoreText.text = "Total points: " + totalPoints.ToString();

        Time.timeScale = 0f;        
        */
        DisplayTopPlayers();
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

