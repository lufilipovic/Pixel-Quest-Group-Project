using UnityEngine;

public class PlaySoundOnTransition : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip transitionSound;

    private SceneTransition sceneTransition;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sceneTransition = GetComponent<SceneTransition>();

        if (sceneTransition == null)
        {
            Debug.LogError("SceneTransition script not found on the same GameObject.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && sceneTransition != null)
        {
            if (sceneTransition.interacted) // Check if the player has interacted with the NPCVillager
            {
                PlaySound();
            }
        }
    }

    private void PlaySound()
    {
        if (audioSource != null && transitionSound != null)
        {
            audioSource.PlayOneShot(transitionSound);
        }
        else
        {
            Debug.LogWarning("AudioSource or TransitionSound not set.");
        }
    }
}

