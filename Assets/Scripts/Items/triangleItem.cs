using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class triangleItem : MonoBehaviour
{
    public int triangleCount;
    public TextMeshProUGUI triangleText;

    // Update the UI text with the current triangle count
    void Update()
    {
        triangleText.text = "Triangles Collected: " + triangleCount.ToString();
    }
}
