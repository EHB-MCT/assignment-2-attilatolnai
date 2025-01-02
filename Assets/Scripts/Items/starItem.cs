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

    //public int starScore => starCount * starPoint;

    // Update the UI text with the current star count
    void Update()
    {
        starText.text = "Stars Collected: " + starCount.ToString();
        starPointsUI.text = "Circle Points: " + (starCount * starPoint).ToString();
    }
}
