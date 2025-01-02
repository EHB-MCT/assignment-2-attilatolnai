using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreCalculator : MonoBehaviour
{
    public circleItem ci;
    public triangleItem ti;
    public starItem si;

    public TextMeshProUGUI totalPointsDisplay;

    private int totalPoints;
    
    void Start()
    {
        if (totalPointsDisplay != null)
        {
            totalPointsDisplay.text = "Total Points: 0";
        }
    }

    public void UpdateTotalScore()
    {
        if (ci != null && ti != null && si != null)
        {
            totalPoints = (ci.circleCount * ci.circlePoint) +
                          (ti.triangleCount * ti.trianglePoint) +
                          (si.starCount * si.starPoint);
        }

        if (totalPointsDisplay != null)
        {
            totalPointsDisplay.text = "Total Points: " + totalPoints.ToString();
        }
    }
}

