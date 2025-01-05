# UIManager Script Documentation

## Overview
The `UIManager` script manages the user interface elements of the game, including the start menu and the game-over menu. It handles player input for their name, controls the visibility of UI components, and triggers when the game can start.

---

## Script Details**

### **Variables:**
- **gameOverMenu (GameObject):** 
  The GameObject representing the game-over UI menu.
- **startMenu (GameObject):** 
  The GameObject representing the start UI menu.
- **playerNameInput (TMP_InputField):** 
  A TextMeshPro input field for the player to enter their name.
- **playerNameText (TextMeshProUGUI):** 
  A TextMeshPro UI element to display the player's name.
- **startButton (Button):** 
  The UI button used to start the game.
- **playerName (string):** 
  Stores the player's name after input is received.
- **isGameRunning (bool):** 
  Indicates whether the game is currently running.
- **GameStartEventHandler:** 
  A delegate used to define the event signature for starting the game.
- **OnGameStart (event):** 
  Event triggered when the game starts, allowing other scripts to subscribe and respond.


## **Methods**

- **void Start()**
  Initializes the UI by enabling the start menu and disabling the game-over menu. Subscribes the `OnStartButtonClicked` method to the `startButton`'s click event.
- **void OnStartButtonClicked()**
   Retrieves the player's name from `playerNameInput` and checks if the input is valid (non-empty). If the input is valid:
     - Hides the start menu.
     - Sets `isGameRunning` to `true`.
     - Triggers the `OnGameStart` event for subscribed listeners.
   If the input is empty, it logs a message.


## **How to Use**
1. Attach the `UIManager` script to a GameObject in your Unity project.
2. Assign the following UI elements in the Inspector:
   - **gameOverMenu:** Drag the GameObject representing the game-over menu.
   - **startMenu:** Drag the GameObject representing the start menu.
   - **playerNameInput:** Assign a TextMeshPro input field for player name input.
   - **playerNameText:** Link a TextMeshPro text field to display the player's name (optional).
   - **startButton:** Assign a Button component for starting the game.

## Sources
- ChatGPT for help with documentation structure: https://chatgpt.com/share/6777fd9a-e788-8007-9266-d94880160040