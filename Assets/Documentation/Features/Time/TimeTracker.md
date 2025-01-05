# TimeTracker Script Documentation

## Overview
This script manages to track the time spent in game.

## Script Details

### **Variables:**
- **timeSpent (float):**
  Tracks the total time spent in game.
- **isGameRunning (bool):**
  Indicates whether the game is active
- **countdownTime (float):**
  Sets the countdown timer to 60 and doesn't allow it to go into the negatives.
- **isCountdownRunning (bool):**
  Checks if the counddown timer is running.
- **gm (gameManager):** 
  Reference to the `gameManager` script, which controls the game's state.

## Methods:

### **Start()**
- Hides the timeUpText TextMeshProUGUI element from the UI.
### **Update()**
- Checks if the game is currently running
- If the game is running, start accumulating the time while the game is running
- Check if the countdown is currently running
- If the countdown is running, start decreasing the value of countdownTime.
### **ResetTime()**
- Reset the accumulated time back to 0.
### **StartCountdown()**
- Reset the countdown to 60 seconds.
- Start the countdown once the game starts.
- Makes sure that the timeUpText TextMeshProUGUI element is still hidden.
### **StopCountdown()**
- If the value of countdownTime reaches zero, stop running the game.
### **UpdateCountdownDisplay()**
- If the countdown timer is not lower or equal to 0, convert the remaining time into minutes and seconds and formats it into MM:SS.
### **StartTimer()**
- Start the timer once the game starts.
  ### **StopTimer()**
- If the game is no longer running, stop accumulating time.
### **UpdateCountdownDisplay()**
- Converts the time into minutes and seconds and formats it into MM:SS.
### **formattedTime**
- Whenever it gets accessed by other scripts, it calculates and returns a formatted string representing the timeSpent in the format MM:SS.
### **EndGame()**
- Checks if the gameManager is not null, then sends a call to execute its `GameOver()` method. 

## How to Use
1. Attach the 'timeTracker' script to the 'TimeManager' GameObject.
2. Attach the 'TimeManager' GameObject to the 'Tt' field inside of the 'GameManager' GameObject's Inspector.

## Sources
- ChatGPT for help with coding: https://chatgpt.com/share/674f031b-b914-8007-b757-66cf45250383
- ChatGPT for help with documentation structure: https://chatgpt.com/share/674876ec-2e5c-8007-b4b3-c50ddd7f8926