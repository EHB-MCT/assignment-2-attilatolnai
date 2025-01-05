# getPreviousTwoGames Script Documentation

## Overview
The `getPreviousTwoGames` script is responsible for retrieving the last two games played by the player from the Firebase database. It compares the data of the current and previous games, including the number of circles, triangles, and stars collected, time spent in game and total points gathered. It then displays the results on the UI. It also provides a visual comparison of scores.

## Script Details

### **Variables:**
- **previousPlayerDataText (TextMeshProUGUI):**  
  UI element that displays the player's previous two game statistics and the comparison results.
- **databaseReference (DatabaseReference):**  
  A reference to the Firebase Realtime Database used to retrieve player data.
- **gm (gameManager):**  
  Reference to the `gameManager` script, used to access the Firebase database and other critical game logic.

## **Methods**
- **FetchPreviousTwoGames(string playerName):**  
  - **Parameters:**  
    - `playerName (string)`: The name of the player whose data is being fetched from Firebase.
  - **Description:**  
    Retrieves the player's data from Firebase, fetches the last two games played by the player, and compares the statistics (circles, triangles, stars, time spent, total points) between the current and previous games.
    - Fetches player data from the Firebase database and retrieves the relevant statistics.
    - Sorts the games by timestamp to ensure the most recent games are selected.
    - Compares the performance between the current and previous game and generates a visual display of the comparison.
    - The comparison includes symbols indicating whether the player did better (+) or worse (-) in terms of circles, triangles, and stars.
    - Displays the comparison results and highlights the total points with a color change based on whether the score was better (in green) or worse (in red) than their previous attempt.
  
- **private string CompareGames(...)**  
  - **Parameters:**  
    - `latestGame (tuple)`: A tuple containing the most recent game's data (`playerName`, `circles`, `triangles`, `stars`, `timeSpent`, `totalPoints`, `timestamp`).
    - `previousGame (tuple)`: A tuple containing the previous game's data (`playerName`, `circles`, `triangles`, `stars`, `timeSpent`, `totalPoints`, `timestamp`).
  - **Return Type:** `string`
  - **Description:**  
    Compares the statistics of the latest game to the previous one and returns a formatted string containing the comparison results. It calculates the differences in circles, triangles, stars, and points, and assigns a color (green, red, or default) based on the score comparison.

## How to Use
1. Attach the `getPreviousTwoGames` script to a GameObject in the Unity Editor.
2. Assign the `previousPlayerDataText` field to a TextMeshProUGUI element that will display the comparison results.
3. Ensure that Firebase is correctly initialized and connected in the project, with access to the player data stored in the Firebase Realtime Database.
4. Call `FetchPreviousTwoGames(playerName)` with the player's name to fetch and compare their last two games.
  
## Sources
ChatGPT:
  - for help with documentation structure: https://chatgpt.com/share/6777fd9a-e788-8007-9266-d94880160040
  - for help with coding: https://chatgpt.com/share/674f031b-b914-8007-b757-66cf45250383
