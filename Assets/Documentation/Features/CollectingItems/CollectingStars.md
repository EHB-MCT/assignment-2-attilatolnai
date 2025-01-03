# starItem Script Documentation

## Overview
This script manages the count of star shaped items collected by the player and updates a UI element to display the count in real-time.

## Script Details

### **Variables:**
- **starCount (int):**
  Stores the number of star items the player has collected. This value is updated externally (e.g., when a star item is picked up).

- **starPoint (int):**
  The amount of points the player is assigned when they collect a star item.

- **starText (TextMeshProUGUI):**
  A reference to the TextMeshProUGUI component in the UI. It is used to display the current star count in the UI.

- **starPointsUI (TextMeshProUGUI):**
  A reference to the TextMeshProUGUI component in the UI. This is where the total points earned by collecting stars will be displayed in the game's interface.

## Methods:

### **Update()**
- Called once per frame.
- Updates the 'starText' UI element to display the latest value of 'starCount' by converting the data into a string.
- Updates the 'starPointsUI' UI element to display the latest result of the calculation that determines how many points the player has scored by collecting stars. This is calculated by taking the value of starCount and multiplying it with the value of starPoint.

## How to Use
1. Attach the 'starItem' script to the 'GameManager' GameObject to track and display the star items.
2. Drag the appropriate TextMeshProUGUI component to the 'starText' field in the Inspector.
3. Drag the appropriate TextMeshProUGUI component to the 'starPointsUI' field in the Inspector.
4. The 'starCount' value gets updated through gameplay when the player collects a GameObject with the tag 'Star'.
5. The value of 'starCount' will be multiplied by the value assigned to 'starPoint' to display the current score in the 'starPointsUI' TextMeshProUGUI element in the game's interface.

## Sources
- Youtube tutorial by MoreBBlakeyyy: https://www.youtube.com/watch?v=5GWRPwuWtsQ
- ChatGPT for help with documentation structure: https://chatgpt.com/share/67600d7e-b92c-8007-9cf7-bbc0b8c4be4b