# PlayerMovement Script Documentation

## Overview
This script manages the player's movement in my 2D top-down Unity game made for Development 5. It uses Unity's Rigidbody2D component to handle movement physics and ensures smooth directional control.

---

## Script Details

### **Fields:**
- **moveSpeed (float):**
  Determines how fast the player moves. This value can be adjusted in the Inspector to balance gameplay.

- **rigidbody (Rigidbody2D):**
  The Rigidbody2D component attached to the player. It allows for physics-based movement.

### **Methods:**
#### `Update()`
- Processes player inputs every frame.
- Calls `ProcessInputs()` to determine the current movement direction.

#### `FixedUpdate()`
- Handles actual player movement at fixed intervals for consistent physics calculations.
- Calls `Move()` to apply velocity to the Rigidbody2D.

#### `ProcessInputs()`
- Reads input from the player (keyboard) using Unity's `Input.GetAxisRaw()` method.
- Normalizes the input to maintain consistent speed regardless of diagonal movement.

#### `Move()`
- Sets the Rigidbody2D's velocity based on the calculated movement direction and speed.

---

## Why This Approach?

### **Why Use Rigidbody2D for Movement?**
- Unity's Rigidbody2D component allows for physics-based movement, ensuring smooth transitions and collisions.
- Using velocity directly offers precise control over movement without needing to manually adjust positions.

### **Why Normalize Movement Direction?**
- Normalizing the direction vector ensures the player moves at a consistent speed in all directions, even diagonally.
- Without normalization, diagonal movement would be faster due to vector addition.

---

## How to Use
1. Attach the `PlayerMovement` script to the player GameObject.
2. Assign the Rigidbody2D component to the `rigidbody` field in the Inspector.
3. Set an appropriate `moveSpeed` value in the Inspector.
4. Ensure Unity's Input settings are configured for "Horizontal" and "Vertical" axes.

---

## Future Improvements
- Add acceleration and deceleration for smoother movement transitions.
- Add sound effects when the player is moving.
- Add collision effect when hitting a wall. 
- Integrate animations based on movement direction.

---

## Author Notes
This script was designed for simplicity and performance. The code adheres to Unity’s best practices for physics-based movement and uses a modular approach, making it easy to extend or adapt for different game mechanics.

## Sources

- Youtube tutorial by BMo: https://www.youtube.com/watch?v=u8tot-X_RBI&t=80s
- ChatGPT for help with documentation structure: https://chatgpt.com/share/674876ec-2e5c-8007-b4b3-c50ddd7f8926