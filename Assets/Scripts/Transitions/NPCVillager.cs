using UnityEngine;

public class NPCVillager : MonoBehaviour
{
    // Reference to the dialogue system component
    public DialogueSystem dialogueSystem;

    // Reference to the scene transition component
    public SceneTransition sceneTransition;

    // Method called when another collider enters the trigger collider attached to the NPC
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            StartDialogue(); // Start the dialogue with the player
        }
    }

    // Method to initiate the dialogue with the player
    private void StartDialogue()
    {
        sceneTransition.interacted = true; // Set the interaction flag in the scene transition component
        dialogueSystem.StartDialog(); // Start the dialogue system
    }
}
