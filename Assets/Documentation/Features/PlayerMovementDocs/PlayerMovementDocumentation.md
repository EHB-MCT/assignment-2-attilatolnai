# PlayerMovement Script Documentation

## Overview
The `PlayerMovement` script handles the player's movement in a 2D game using `Rigidbody2D` physics. It also processes player input, manages collisions with game objects, and interacts with other scripts to update scores and game state.

## Script Details

### **Variables:**
- **moveSpeed (float):** 
  The movement speed of the player.
- **rigidbody (Rigidbody2D):** 
  Reference to the `Rigidbody2D` component attached to the player GameObject.
- **moveDirection (Vector2):** 
  The current movement direction of the player.
- **ci (circleItem):** 
  Reference to the `circleItem` script, which tracks the count and point value of collected circles.
- **ti (triangleItem):** 
  Reference to the `triangleItem` script, which tracks the count and point value of collected triangles.
- **si (starItem):** 
  Reference to the `starItem` script, which tracks the count and point value of collected stars.
- **gm (gameManager):** 
  Reference to the `gameManager` script, which controls the game's state.
- **sc (ScoreCalculator):** Reference to the `ScoreCalculator` script, which calculates the player's total score and keeps updating it while the game runs.

## Methods
- **Update():** 
  - Called every frame to process player input and update the movement direction.
  - Calls the `ProcessInputs()` method.

- **FixedUpdate():**
  - Called at fixed intervals to apply movement to the player.
  - Calls the `Move()` method.

- **ProcessInputs():**
  - Checks for player input using the keyboard.
  - Updates `moveDirection` based on the input, normalizing the vector to ensure consistent movement speed.

- **Move():**
  - Applies movement to the player by updating the velocity of the `Rigidbody2D` component.
  
- **OnTriggerEnter2D(Collider2D other):**
  Detects collisions with other objects and executes appropriate actions:
    - **If the collided object has a "Circle" tag:**
      - Increments the circle counter in the `circleItem` script.
      - Updates the total score using the `ScoreCalculator`.
      - Destroys the collided object.
    - **If the collided object has a "Triangle" tag:**
      - Increments the triangle counter in the `triangleItem` script.
      - Updates the total score using the `ScoreCalculator`.
      - Destroys the collided object.
    - **If the collided object has a "Star" tag:**
      - Increments the star counter in the `starItem` script.
      - Updates the total score using the `ScoreCalculator`.
      - Destroys the collided object.
    - **If the collided object has a "StartArea" tag:**
      - Checks if any items were collected. If so, triggers the game-over state by calling `GameOver()` in the `gameManager`.


## How to Use
1. Attach the `PlayerMovement` script to the player GameObject in the Unity Editor.
2. Assign the `Rigidbody2D` component of the player to the `rigidbody` variable.
3. Set an appropriate value for the `moveSpeed` variable to control the player's movement speed.
4. Link the `circleItem`, `triangleItem`, `starItem`, `gameManager`, and `ScoreCalculator` scripts in the Inspector.
5. Ensure that objects in the game have the appropriate tags ("Circle", "Triangle", "Star", "StartArea") for collision detection.

## Sources
- Youtube tutorial by BMo: https://www.youtube.com/watch?v=u8tot-X_RBI&t=80s
- ChatGPT for help with documentation structure: https://chatgpt.com/share/6777fd9a-e788-8007-9266-d94880160040