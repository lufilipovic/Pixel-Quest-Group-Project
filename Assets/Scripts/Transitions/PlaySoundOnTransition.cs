using UnityEngine;

public class PlaySoundOnTransition : MonoBehaviour
{
    private AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip transitionSound; // Audio clip to play on transition

    private SceneTransition sceneTransition; // Reference to the SceneTransition component

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component attached to the GameObject
        sceneTransition = GetComponent<SceneTransition>(); // Get the SceneTransition component attached to the GameObject

        // Check if the SceneTransition component is found
        if (sceneTransition == null)
        {
            Debug.LogError("SceneTransition script not found on the same GameObject."); // Log an error if not found
        }
    }

    // Method called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player and the scene transition component is not null
        if (other.CompareTag("Player") && sceneTransition != null)
        {
            // Check if the player has interacted with the NPCVillager
            if (sceneTransition.interacted)
            {
                PlaySound(); // Play the transition sound
            }
        }
    }

    // Method to play the transition sound
    private void PlaySound()
    {
        // Check if the AudioSource and TransitionSound are set
        if (audioSource != null && transitionSound != null)
        {
            audioSource.PlayOneShot(transitionSound); // Play the transition sound
        }
        else
        {
            Debug.LogWarning("AudioSource or TransitionSound not set."); // Log a warning if not set
        }
    }
}
