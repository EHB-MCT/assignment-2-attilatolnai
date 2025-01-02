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

    //public int triangleScore => triangleCount * triangePoint;
    // Update the UI text with the current triangle count
    void Update()
    {
        triangleText.text = "Triangles Collected: " + triangleCount.ToString();
        trianglePointsUI.text = "Triangle Points: " + (triangleCount * trianglePoint).ToString();
    }
}
