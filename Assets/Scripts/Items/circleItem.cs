using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Tracks and displays the amount of circle items collected by the player.
public class circleItem : MonoBehaviour
{
    //The number of circle items the player has collected.
    public int circleCount;
    //Reference to the TextMeshProUGUI component used to display the circle count.
    public TextMeshProUGUI circleText;

    public GameObject startArea;
    public GameObject gameOverMenu;
    public TextMeshProUGUI circlesCollectedText;
    public TextMeshProUGUI timeSpentText;

    public TMP_InputField playerNameInput;
    public gameManager gameManager;

    private float timeSpent;
    private bool isGameRunning = true;

    // Update the text component to show the current circle count.
    void Update()
    {
        if (isGameRunning)
        {
            timeSpent += Time.deltaTime;
        }

        circleText.text = "Circle Count: " + circleCount.ToString();

        if(circleCount > 0 && !startArea.activeSelf)
        {
            startArea.SetActive(true);
        }
    }

    public void TriggerGameOver()
    {
        if(gameManager != null)
        {
            gameManager.GameOver();
        }
        else
        {
            Debug.LogError("gameManager reference is not set!");
        }
    }

    /*
    public void GameOver()
    {
        isGameRunning = false;

        gameOverMenu.SetActive(true);

        FetchPreviousPlayerData();

        circlesCollectedText.text = "Circles collected: " + circleCount.ToString();
        timeSpentText.text = "Time spent: " + Mathf.FloorToInt(timeSpent) + "seconds";

        Time.timeScale = 0f;
    }
    */

    public void SubmitDataToFirebase()
    {
        string playerName = playerNameInput.text;

        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Player name is empty!");
            return;
        }

        gameManager.SubmitPlayerData(playerName, circleCount, Mathf.FloorToInt(timeSpent));
    }

    void FetchData()
    {
        if (gameManager != null)
        {
            gameManager.FetchPreviousPlayerData();
        }
        else
        {
            Debug.LogError("gameManager reference is not set!");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
