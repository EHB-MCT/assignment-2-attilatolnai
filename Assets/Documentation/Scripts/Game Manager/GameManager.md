
# gameManager Script Documentation

## Overview
The `gameManager` script serves as the main controller for managing the game's state. It also includes initializing Firebase, handling what happens when the game-over is triggered, updating certain UI elements, and fetching player data.

## Script Details

### **Variables:**
- **app (Firebase.FirebaseApp):** 
  Instance of the Firebase application.
- **_databaseReference (DatabaseReference):** 
  Reference to the Firebase database.
- **firebaseInitialized (bool):** 
  Indicates whether Firebase is initialized. When the game starts, it is set to 'false'
- **gameOverMenu (GameObject):** 
  Reference to the UI panel that appears when the game over is triggered.
- **playerNameInput (TMP_InputField):** 
  Input field that appears at the start of the game. This is where the player enters their name.
- **circlesCollectedText (TextMeshProUGUI):** 
  UI text displaying the number of circles the player collected.
- **circlePointsUI (TextMeshProUGUI):** 
  UI text displaying the points earned from collecting circles.
- **trianglesCollectedText (TextMeshProUGUI):** 
  UI text displaying the number of triangles the player collected.
- **trianglePointsUI (TextMeshProUGUI):** 
  UI text displaying the points earned from collecting triangles.
- **starsCollectedText (TextMeshProUGUI):** 
  UI text displaying the number of stars the player collected.
- **starPointsUI (TextMeshProUGUI):** 
  UI text displaying points earned from collecting stars.
- **timeSpentText (TextMeshProUGUI):** 
  UI text displaying the total time the player spent in the game.
- **previousPlayerDataText (TextMeshProUGUI):** 
  UI text displaying data of the player's attempt.
- **displayPlayerName (TextMeshProUGUI):** 
  UI text displaying the current player's name.
- **totalScoreText (TextMeshProUGUI):** 
  UI text displaying the player's total score.
- **topPlayersDataText (TextMeshProUGUI):** 
  UI text displaying the data which is used to display the leaderboard.
- **circleCount (int):** 
  Count of circles the player collected during the game.
- **triangleCount (int):** 
  Count of triangles the player collected during the game.
- **starCount (int):** 
  Count of stars the player collected during the game.
- **timeSpent (float):** 
  Total time the player spent in the game.
- **isGameRunning (bool):** 
  Indicates whether the game is currently running.
- **playerName (string):** 
  Name of the player.

### **References to Other Scripts:**
- **circleItem (ci):** 
  Handles the gameplay logic related to the circle item the player has to collect.
- **triangleItem (ti):** 
  Handles the gameplay logic related to the triangle item the player has to collect.
- **starItem (si):** 
  Handles the gameplay logic related to the star item the player has to collect.
- **timeTracker (tt):** 
  Tracks and manages game time.
- **sendPlayerData (spd):** 
  Submits player data to the Firebase database.
- **UIManager (uim):** 
  Manages UI-related logic.
- **ScoreCalculator (sc):** 
  Calculates the total score by adding up the points from the circles, triangles and stars collected by the player.
- **Leaderboard (lb):** 
  Fetches and displays the data of the players with the highest score achieved in the game in the form of a leaderboard.
- **getPreviousTwoGames (gptg):** 
  Fetches and displays the players last two games.
- **compareToHighscore (cth):** 
  Fetches and displays the players latest game with his best game to compare the stats.

## **Methods**
- **Start():** 
  Initializes Firebase connection, disables the gameOverMenu in the UI and makes sure that the player field is not empty when starting.
- **OnGameStart():** 
  Resets the timer back to 0 and the countdown back to 60 and then starts them.
- **InitializeFirebase():** 
  Sets up Firebase dependencies and initializes the database reference.
- **GameOver():** 
  Handles the game-over state. It submits the player's data to another script and then calls 'FetchPreviousTwoGames()', 'CompareToHighscore' and 'DisplayTopPlayers()' from other scripts.
- **DisplayTopPlayers():** 
  Once called, it fetches the players with the highest score and displays them in the game over menu.

## How to Use
1. Attach the `gameManager` script to a GameObject in the Unity Editor.
2. Assign references for all public variables in the Inspector.
3. Ensure that Firebase is properly set up in the project, with database rules configured to allow access.
4. Call `GameOver()` when the game ends to handle the game-over state and update data.

## Sources
- Youtube tutorial by MoreBBlakeyyy: https://www.youtube.com/watch?v=5GWRPwuWtsQ
- Separation of concerns: https://www.geeksforgeeks.org/separation-of-concerns-soc/
- Firebase tutorials:
  - https://firebase.google.com/docs/unity/setup
  - https://firebase.google.com/docs/database
  - Youtube tutorial by Coco 3D: https://www.youtube.com/watch?v=hAa5exkTsKI&t=388s
- ChatGPT:
  - for help with documentation structure: https://chatgpt.com/share/6777fd9a-e788-8007-9266-d94880160040
  - for help with coding: https://chatgpt.com/share/674f031b-b914-8007-b757-66cf45250383