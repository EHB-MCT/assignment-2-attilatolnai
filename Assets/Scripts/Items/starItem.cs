using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class starItem : MonoBehaviour
{
    public int starCount;
    public int starPoint = 1000;
    public TextMeshProUGUI starText;
    public TextMeshProUGUI starPointsUI;

    //Displays the amount of stars collected and points scored from star items in the game's interface.
    void Update()
    {
        starText.text = "Stars Collected: " + starCount.ToString();
        starPointsUI.text = "Circle Points: " + (starCount * starPoint).ToString();
    }
}
