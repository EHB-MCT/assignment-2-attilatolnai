# circleItem Script Documentation

## Overview
This script manages the count of circle shaped items collected by the player and updates a UI element to display the count in real-time.

## Script Details

### **Variables:**
- **circleCount (int):**
  Stores the number of circle items the player has collected. This value is updated externally (e.g., when a circle item is picked up).

- **circlePoint (int):**
  The amount of points the player is assigned when they collect a circle item.

- **circleText (TextMeshProUGUI):**
  A reference to the TextMeshProUGUI component in the UI. This is where the amount of circles the player has collected will be displayed in the game's interface.

- **circlePointsUI (TextMeshProUGUI):**
  A reference to the TextMeshProUGUI component in the UI. This is where the total points earned by collecting circles will be displayed in the game's interface.

## Methods:

### **Update()**
- Called every frame.
- Updates the 'circleText' UI element to display the latest value of 'circleCount' by converting the data into a string.
- Updates the 'circlePointsUI' UI element to display the latest result of the calculation that determines how many points the player has scored by collecting circles. This is calculated by taking the value of circleCount and multiplying it with the value of circlePoint.

## How to Use
1. Attach the 'circleItem' script to the 'GameManager' GameObject to track and display the circle items.
2. Drag the appropriate TextMeshProUGUI component to the 'circleText' field in the Inspector.
3. Drag the appropriate TextMeshProUGUI component to the 'circlePointsUI' field in the Inspector.
4. The 'circleCount' and value gets updated through gameplay when the player collects a GameObject with the tag 'Circle'.
5. The value of 'circleCount' will be multiplied by the value assigned to 'circlePoint' to display the current score in the 'circlePointsUI' TextMeshProUGUI element in the game's interface.

## Sources
- Youtube tutorial by MoreBBlakeyyy: https://www.youtube.com/watch?v=5GWRPwuWtsQ
- ChatGPT for help with documentation structure: https://chatgpt.com/share/67600d7e-b92c-8007-9cf7-bbc0b8c4be4b