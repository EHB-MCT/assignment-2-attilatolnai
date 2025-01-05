# sendPlayerData Script Documentation

## Overview
The `sendPlayerData` script handles sending the player's data to a Firebase Realtime Database after the game is over. It ensures data is stored in the "scores" node of the database and uses Unity's Firebase SDK for communication.

### **Variables:**
- **databaseReference (DatabaseReference):** 
  Reference to the Firebase Realtime Database.
- **gm (gameManager):** 
  Reference to the `gameManager` script for Firebase initialization and database access.

## Methods
- **SubmitPlayerData(string playerName, int circleCount, int triangleCount, int starCount, string formattedTime, int totalPoints):**
  Submits player data to the Firebase Realtime Database under the "scores" node.
  - **Parameters:**
    - **playerName (string):** The name of the player.
    - **circleCount (int):** The number of circles collected by the player.
    - **triangleCount (int):** The number of triangles collected by the player.
    - **starCount (int):** The number of stars collected by the player.
    - **formattedTime (string):** The total time spent by the player in the game in the MM:SS format.
    - **totalPoints (int):** The total score achieved by the player.
  - **Functionality:**
    - Retrieves the `DatabaseReference` from the `gameManager` script if Firebase is initialized.
    - Creates a unique key for the new entry using `Push().Key`.
    - Prepares the player data as a dictionary.
    - Submits the data to the "scores" node in Firebase.
    - Logs success or failure messages based on the result of the submission.

## How to Use
1. Attach the `sendPlayerData` script to a GameObject in your Unity project.
2. Assign the `gameManager` script instance to the `gm` variable in the Inspector.
3. Ensure that Firebase is properly configured in the Unity project and that the `gameManager` script initializes Firebase successfully.
4. Call the `SubmitPlayerData()` method with the appropriate parameters to submit player data.

## Sources
- Firebase tutorials:
  - https://firebase.google.com/docs/unity/setup
  - https://firebase.google.com/docs/database
  - Youtube tutorial by Coco 3D: https://www.youtube.com/watch?v=hAa5exkTsKI&t=388s
- ChatGPT:
  - for help with documentation structure: https://chatgpt.com/share/6777fd9a-e788-8007-9266-d94880160040
  - for help with coding: https://chatgpt.com/share/674f031b-b914-8007-b757-66cf45250383
