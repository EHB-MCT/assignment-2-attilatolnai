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
    public TextMeshProUGUI startAreaText;

    // Update the text component to show the current circle count.
    void Update()
    {
        circleText.text = "Circle Count: " + circleCount.ToString();
        if(circleCount > 0 && !startArea.activeSelf)
        {
            startArea.SetActive(true);
        }
    }
}
