# soundEffects Script Documentation

## Overview
The `soundEffects` script is responsible for playing sound effects in the game. Specifically, it manages the sound effect for when the player collects items.

## Script Details

### **Variables:**
- **audioSource (AudioSource):**  
  A reference to the `AudioSource` component attached to the GameObject. This component is responsible for playing audio clips.
- **collectSound (AudioClip):**  
  The audio clip that will be played when an item is collected.

## **Methods**
- **PlayCollectSound():**  
  - **Description:**  
    Plays the `collectSound` audio clip using the `AudioSource` component. This function is triggered whenever the player collects an item in the game.  
  - **Implementation:**  
    Utilizes the `PlayOneShot(AudioClip)` method of the `AudioSource` to play the sound without interrupting any other sounds that might be playing.

## How to Use
1. Attach the `soundEffects` script to a GameObject in the Unity Editor.
2. Add an `AudioSource` component to the same GameObject if it doesn’t already exist.
3. Assign the `audioSource` variable in the Inspector by dragging the AudioSource component to the script's field.
4. Assign an appropriate `AudioClip` to the `collectSound` variable in the Inspector.
5. Call the `PlayCollectSound()` method when an item is collected in the game (e.g., from another script or a Unity event).

## Notes
- Ensure that the `AudioSource` component has its spatial blend settings configured correctly if the game uses 3D audio.
- Adjust the volume of the `AudioSource` in the Inspector for consistent sound levels.

## Sources
- How to add multiple sound effects in Unity by The Dev Show: https://www.youtube.com/watch?v=mvaUho_a-q4&t=116s
- ChatGPT:
  - for help with documentation structure: https://chatgpt.com/share/6777fd9a-e788-8007-9266-d94880160040
  - for help with coding: https://chatgpt.com/share/674f031b-b914-8007-b757-66cf45250383