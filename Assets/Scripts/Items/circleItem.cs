using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class circleItem : MonoBehaviour
{
    public int circleCount;
    public TextMeshProUGUI circleText;
    void Start()
    {
        
    }

    
    void Update()
    {
        circleText.text = "Circle Count: " + circleCount.ToString();
    }
}
