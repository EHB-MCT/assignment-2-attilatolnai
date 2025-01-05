# Leaderboard Script Documentation

## Overview
The `Leaderboard` script retrieves and displays the top 10 players based on their total points from a Firebase Realtime Database. It fetches and sorts player data and updates a UI element to look like a leaderboard.

### **Variables:**
- **topPlayersDataText (TextMeshProUGUI):** 
  A reference to the UI component where the leaderboard data will be displayed.
- **databaseReference (DatabaseReference):** 
  A Firebase reference for interacting with the database.

## Methods
- **void Initialize(DatabaseReference dbReference):**
Sets the `databaseReference` to the provided Firebase database reference.

- **Parameters:**
  - **dbReference (DatabaseReference):** 
  A Firebase database reference to initialize the script.

- **void FetchTopPlayers():**
  Fetches the top 10 players from the Firebase database based on their total points. It also updates the `topPlayersDataText` UI with the leaderboard information.
- **Logic Flow:**
  1. Ensures the `databaseReference` is initialized.
  2. Queries the "scores" child in the database, ordering by `totalPoints` in descending order.
  3. Limits the results to the top 10 entries.
  4. Parses the fetched data and sorts it.
  5. Updates the leaderboard UI with player names and scores.
- **Error Handling:**
  Logs an error and updates the UI with a fallback message if the database is uninitialized or the fetch fails.

## How to Use
1. Attach the `Leaderboard` script to a GameObject in your Unity project.
2. Assign a `TextMeshProUGUI` component to the `topPlayersDataText` variable in the Inspector to display leaderboard data.
3. Call `Initialize()` and provide a valid Firebase `DatabaseReference` to set up the connection.
4. Invoke `FetchTopPlayers()` to fetch and display the top 10 players in the leaderboard.

## Sources
ChatGPT:
  - for help with documentation structure: https://chatgpt.com/share/6777fd9a-e788-8007-9266-d94880160040
  - for help with coding: https://chatgpt.com/share/674f031b-b914-8007-b757-66cf45250383