# circleItem Script Documentation

## Overview
This script manages the count of "circle" items collected by the player and updates a UI element to display the count in real-time.

---

## Script Details

### **Fields:**
- **circleCount (int):**
  Stores the number of circle items the player has collected. This value is updated externally (e.g., when a circle item is picked up).

- **circleText (TextMeshProUGUI):**
  A reference to the TextMeshProUGUI component in the UI. It is used to display the current circle count.

---

## Methods:

### **Update()**
- Called every frame.
- Updates the `circleText` UI element to display the latest value of `circleCount`.

---

## Why This Approach?

### **Why Use TextMeshProUGUI?**
- TextMeshPro provides higher-quality text rendering than Unity's default `Text` component.
- It supports advanced text formatting, which could be useful for future UI enhancements.

### **Why Update the Text in Update()?**
- Ensures the displayed circle count is always synchronized with the `circleCount` value.
- Suitable for games where the count might change dynamically.

---

## How to Use
1. Attach the `circleItem` script to a GameObject responsible for tracking and displaying circle items.
2. Drag the appropriate TextMeshProUGUI component to the `circleText` field in the Inspector.
3. Update the `circleCount` value through gameplay events (e.g., collecting items).

---

## Future Improvements
- Add event-driven updates instead of updating the text in `Update()` to improve performance.
- Include animations or effects when the circle count changes.
- Generalize the script to support other item types.

---

## Author Notes
This script was designed for simplicity and focuses on real-time updates to the circle item count. It can be extended for additional functionality or item types.

## Sources
- Youtube tutorial by MoreBBlakeyyy: https://www.youtube.com/watch?v=5GWRPwuWtsQ
- ChatGPT for help with documentation structure: https://chatgpt.com/share/674876ec-2e5c-8007-b4b3-c50ddd7f8926
