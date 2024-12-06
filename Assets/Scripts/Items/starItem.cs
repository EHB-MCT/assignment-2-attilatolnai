using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class starItem : MonoBehaviour
{
    public int starCount;
    public TextMeshProUGUI starText;
    public gameManager gm; // Reference to the GameManager

    void Update()
    {
        // Update the UI text with the current star count
        starText.text = "Stars Collected: " + starCount.ToString();
    }

    public void GameOver()
    {
        gm.GameOver();
    }
}
