# replayGame Script Documentation

## Overview
This script manages to restart the game without having to quit the game.

## Script Details

## Methods:

### **RestartGame()**
- Restarts the current scene and resumes the game's time if it wasn't running already.
- `Time.timeScale = 1f;`: Resumes the game by setting time back to normal speed.
- `SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);`: Reloads the current active scene.

## How to Use
1. Attach the 'replayGame' script to the 'ReplayManager' GameObject.
2. Create a UI Button and assign the RestartGame() method to the button's OnClick event in the Inspector.
3. Make sure the scene is included in the Unity Build Settings

## Sources
- ChatGPT for help with coding: https://chatgpt.com/share/674f031b-b914-8007-b757-66cf45250383
- ChatGPT for help with documentation structure: https://chatgpt.com/share/674876ec-2e5c-8007-b4b3-c50ddd7f8926