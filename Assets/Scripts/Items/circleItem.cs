using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Tracks and displays the amount of circle items collected by the player.
public class circleItem : MonoBehaviour
{
    public int circleCount;
    public TextMeshProUGUI circleText;

    //Update the UI text with the current circle count
    void Update()
    {
        circleText.text = "Circle Count: " + circleCount.ToString();
    }
}
