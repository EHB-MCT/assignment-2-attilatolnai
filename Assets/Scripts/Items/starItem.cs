using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class starItem : MonoBehaviour
{
    public int starCount;
    public TextMeshProUGUI starText;

    // Update the UI text with the current star count
    void Update()
    {
        starText.text = "Stars Collected: " + starCount.ToString();
    }
}
