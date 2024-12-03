# GameOverScreen feature documentation

## Overview
# This feature had as goals:
- To add a game over screen when the player collides with the starting area whenever the player has at least one circle in his possesion.
- Display the amount of circles collected and time spent in game
- Display an inputfield where the player can type their name
- Send the playername, circles collected and their playtime to the firebase database
- Get data from the Firebase database and display it inside the game over screen

## How
- Create a panel with an inputfield, textfields for circles collected, time spent playing & display previous player's data.
- At the start of the game, hide the game over screen panel. 
- When the player collides with the starting area after collecting atleast one circle, stop the player from moving and unhide the game over screen
- If there is a previous player, it will get their data from the database and display it in the game over screen.
- Let the player input a name in the inputfield
- If the player clicks on the send data button, their data will be sent to the Firebase database

## Sources
- Youtube tutorial by Coco 3D: https://www.youtube.com/watch?v=hAa5exkTsKI&t=388s
- Firebase setup for Unity: https://firebase.google.com/docs/unity/setup 
- ChatGPT: https://chatgpt.com/share/674f031b-b914-8007-b757-66cf45250383