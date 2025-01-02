# triangleItem Script Documentation

## Overview
This script manages the count of triangle shaped items collected by the player and updates a UI element to display the count in real-time.

## Script Details

### **Variables:**
- **triangleCount (int):**
  Stores the number of triangle items the player has collected. This value is updated externally (e.g., when a triangle item is picked up).

- **triangleText (TextMeshProUGUI):**
  A reference to the TextMeshProUGUI component in the UI. It is used to display the current triangle count in the UI.

## Methods:

### **Update()**
- Called once per frame.
- Updates the 'triangleText' UI element to display the latest value of 'triangleCount' by converting the data into a string.

## How to Use
1. Attach the 'triangleItem' script to the 'GameManager' GameObject to track and display the triangle items.
2. Drag the appropriate TextMeshProUGUI component to the 'triangleText' field in the Inspector.
3. The 'triangleCount' value gets updated through gameplay when the player collects a GameObject with the tag 'Triangle'.

## Sources
- Youtube tutorial by MoreBBlakeyyy: https://www.youtube.com/watch?v=5GWRPwuWtsQ
- ChatGPT for help with documentation structure: https://chatgpt.com/share/67600d7e-b92c-8007-9cf7-bbc0b8c4be4b
