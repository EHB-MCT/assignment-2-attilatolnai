using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class triangleItem : MonoBehaviour
{
    public int triangleCount;
    public TextMeshProUGUI triangleText;
    public gameManager gm; // Reference to the GameManager

    void Update()
    {
        // Update the UI text with the current triangle count
        triangleText.text = "Triangles Collected: " + triangleCount.ToString();
    }

    public void GameOver()
    {
        gm.GameOver();
    }
}
