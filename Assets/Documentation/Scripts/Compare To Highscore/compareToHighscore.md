# compareToHighscore Script Documentation

## Overview
The `compareToHighscore` script retrieves and compares the player's latest game data with their highest-scoring game from the Firebase database. It displays the results of the comparisons, including the number of circles, triangles, and stars collected while also comparing the total points between the latest and highest-scoring games.

## **Script Details**

### **Variables:**
- **compareHighscore (TextMeshProUGUI):**
  The TextMeshPro UI element that displays the comparison between the latest and highest-scoring games.
- **motivationalMessage (TextMeshProUGUI):** 
  The TextMeshPro UI element that shows motivational messages based on the player's performance.
- **gm (gameManager):**
  A reference to the `gameManager` script, which is used to access Firebase and other game-related data.
- **databaseReference (DatabaseReference):**
  A reference to the Firebase Realtime Database used to retrieve and store player data.

## **Methods**

- **CompareToHighscore(string playerName):**  
  - **Parameters:**  
    - `playerName (string)`: The player's name, used to fetch their game data from Firebase.
  - **Description:**  
    Retrieves the player's game data from Firebase, compares their latest game to their highest-scoring game, and displays the comparison results in the UI.
    - Fetches all the games played by the player from Firebase.
    - Sorts the games by timestamp to get the latest game and highest-scoring game.
    - Compares the number of circles, triangles, stars, and total points between the two games.
    - Displays the comparison and provides motivational feedback based on the player's performance.

- **private string CompareGames(...)**  
  - **Parameters:**  
    - `latestGame (tuple)`: A tuple containing the latest game's data (`playerName`, `circles`, `triangles`, `stars`, `timeSpent`, `totalPoints`, `timestamp`).
    - `highestScoringGame (tuple)`: A tuple containing the highest-scoring game's data (`playerName`, `circles`, `triangles`, `stars`, `timeSpent`, `totalPoints`, `timestamp`).
  - **Return Type:** `string`
  - **Description:**  
    Compares the two games' data (latest vs highest scoring) and generates a comparison string. It compares each category (circles, triangles, stars, and total points) and provides motivational feedback based on whether the latest game score is higher or lower than the highest score.

## How to Use
1. Attach the `compareToHighscore` script to a GameObject in the Unity Editor.
2. Assign references for the public UI elements (`compareHighscore` and `motivationalMessage`) in the Inspector.
3. Ensure Firebase is properly initialized and connected in the project.
4. Call `CompareToHighscore(playerName)` with the player's name to compare their latest game to their highest-scoring game.

## Sources
ChatGPT:
  - for help with documentation structure: https://chatgpt.com/share/6777fd9a-e788-8007-9266-d94880160040
  - for help with coding: https://chatgpt.com/share/674f031b-b914-8007-b757-66cf45250383