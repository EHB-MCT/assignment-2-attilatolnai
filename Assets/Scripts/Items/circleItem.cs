using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class circleItem : MonoBehaviour
{
    public int circleCount;
    public int circlePoint = 100;
    public TextMeshProUGUI circleText;
    public TextMeshProUGUI circlePointsUI;
    
    //Displays the amount of circles collected and points scored from circle items in the game's interface.
    void Update()
    {
       circleText.text = "Circle Count:" + circleCount.ToString();
       circlePointsUI.text = "Circle Points:" + (circleCount * circlePoint).ToString();
    }
}
