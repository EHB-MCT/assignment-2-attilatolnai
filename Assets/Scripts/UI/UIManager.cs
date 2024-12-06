using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public GameObject gameOverMenu;
    public GameObject startMenu;

    public TMP_InputField playerNameInput;
    public TextMeshProUGUI playerNameText;
    public Button startButton;

    public string playerName;

    public bool isGameRunning = false;


    void Start()
    {
        
        startMenu.SetActive(true);
        gameOverMenu.SetActive(false);

        startButton.onClick.AddListener(OnStartButtonClicked);
    }

    // Update is called once per frame
    void OnStartButtonClicked()
    {
        playerName = playerNameInput.text;

        if (!string.IsNullOrEmpty(playerName))
        {
            startMenu.SetActive(false);
            isGameRunning = true;
        }
        else
        {
            Debug.Log("Please enter a name before starting!");
        }
    }
}
