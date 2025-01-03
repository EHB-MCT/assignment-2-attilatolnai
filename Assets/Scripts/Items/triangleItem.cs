using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class triangleItem : MonoBehaviour
{
    public int triangleCount;
    public int trianglePoint = 300;
    public TextMeshProUGUI triangleText;
    public TextMeshProUGUI trianglePointsUI;

    //Displays the amount of triangles collected and points scored from triangle items in the game's interface.
    void Update()
    {
        triangleText.text = "Triangles Collected: " + triangleCount.ToString();
        trianglePointsUI.text = "Triangle Points: " + (triangleCount * trianglePoint).ToString();
    }
}
