using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonSFX : MonoBehaviour
{
    public AudioSource myFx; // Reference to the AudioSource component
    public AudioClip hoverFx; // Audio clip to play when the button is hovered over
    public AudioClip clickFx; // Audio clip to play when the button is clicked

    // Method to play the hover sound effect
    public void HoverSound()
    {
        myFx.PlayOneShot(hoverFx); // Play the hover sound effect
    }

    // Method to play the click sound effect
    public void ClickSound()
    {
        myFx.PlayOneShot(clickFx); // Play the click sound effect
    }
}
