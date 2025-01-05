# ScoreCalculator Script Documentation

## Overview
The `ScoreCalculator` script calculates and updates the player's total score based on the number of collected items and their respective point values. It also updates the UI to display the total points in real-time.

### **Variables:**
- **ci (circleItem):** 
  Reference to the `circleItem` script, which tracks the count and point value of collected circles.
- **ti (triangleItem):** 
  Reference to the `triangleItem` script, which tracks the count and point value of collected triangles.
- **si (starItem):** 
  Reference to the `starItem` script, which tracks the count and point value of collected stars.
- **totalPointsDisplay (TextMeshProUGUI):** 
  UI element that displays the player's total score.
- **totalPoints (int):** 
  Stores the calculated total score of the player.

## Methods
- **void Start():**
  Initializes the total points display to "Total Points: 0" if the `totalPointsDisplay` UI element is assigned.

- **void UpdateTotalScore():**
  Calculates the total score by multiplying the count of each item by its respective point value and summing them up. It then updates the `totalPointsDisplay` UI element with the new total score.
  - **Dependencies:**
    - `circleItem`, `triangleItem`, and `starItem` scripts must be assigned and properly configured.

- **int GetTotalPoints():**
Returns the current total score.


## How to Use
1. Attach the `ScoreCalculator` script to a GameObject in your Unity project.
2. Assign references to the `circleItem`, `triangleItem`, and `starItem` scripts in the Inspector.
3. Assign a `TextMeshProUGUI` component to the `totalPointsDisplay` variable to display the total score in the UI.
4. Call `UpdateTotalScore()` whenever the player's score changes (e.g., when they collect an item).
5. Use `GetTotalPoints()` to retrieve the player's total score for other game functionalities.

## Sources
ChatGPT:
  - for help with documentation structure: https://chatgpt.com/share/6777fd9a-e788-8007-9266-d94880160040
  - for help with coding: https://chatgpt.com/share/674f031b-b914-8007-b757-66cf45250383