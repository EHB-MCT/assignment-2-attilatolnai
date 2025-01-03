# triangleItem Script Documentation

## Overview
This script manages the count of triangle shaped items collected by the player and updates a UI element to display the count in real-time.

## Script Details

### **Variables:**
- **triangleCount (int):**
  Stores the number of triangle items the player has collected. This value is updated externally (e.g., when a triangle item is picked up).

- **trianglePoint (int):**
  The amount of points the player is assigned when they collect a triangle item.

- **triangleText (TextMeshProUGUI):**
  A reference to the TextMeshProUGUI component in the UI. This is where the amount of triangles the player has collected will be displayed in the game's interface.

- **trianglePointsUI (TextMeshProUGUI):**
  A reference to the TextMeshProUGUI component in the UI. This is where the total points earned by collecting triangles will be displayed in the game's interface.

## Methods:

### **Update()**
- Called once per frame.
- Updates the 'triangleText' UI element to display the latest value of 'triangleCount' by converting the data into a string.
- Updates the 'trianglePointsUI' UI element to display the latest result of the calculation that determines how many points the player has scored by collecting triangles. This is calculated by taking the value of triangleCount and multiplying it with the value of trianglePoint.

## How to Use
1. Attach the 'triangleItem' script to the 'GameManager' GameObject to track and display the triangle items.
2. Drag the appropriate TextMeshProUGUI component to the 'triangleText' field in the Inspector.
3. Drag the appropriate TextMeshProUGUI component to the 'trianglePointsUI' field in the Inspector.
4. The 'triangleCount' value gets updated through gameplay when the player collects a GameObject with the tag 'Triangle'.
5. The value of 'triangleCount' will be multiplied by the value assigned to 'trianglePoint' to display the current score in the 'trianglePointsUI' TextMeshProUGUI element in the game's interface.

## Sources
- Youtube tutorial by MoreBBlakeyyy: https://www.youtube.com/watch?v=5GWRPwuWtsQ
- ChatGPT for help with documentation structure: https://chatgpt.com/share/67600d7e-b92c-8007-9cf7-bbc0b8c4be4b
