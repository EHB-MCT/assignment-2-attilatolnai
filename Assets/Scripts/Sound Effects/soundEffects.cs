using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundEffects : MonoBehaviour
{
    public AudioSource audioSource;  // Reference to the AudioSource component
    public AudioClip collectSound;  // The AudioClip for the collection sound

    // Function to play the collection sound effect
    public void PlayCollectSound()
    {
        audioSource.PlayOneShot(collectSound);  // Corrected variable name here
    }
}
