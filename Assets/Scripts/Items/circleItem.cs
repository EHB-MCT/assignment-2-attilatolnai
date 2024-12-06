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

    //Inputfield for player name
    public TMP_InputField playerNameInput;

    //Call the gameManager script
    public gameManager gameManager;

    /*
    private float timeSpent;
    private bool isGameRunning = true;
    */

    // Update the text component to show the current circle count.
    void Update()
    {
        circleText.text = "Circle Count: " + circleCount.ToString();
    }

    //Trigger to send data to database
    /*
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
    */

    //Get data from database
    /*
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
    */
}
