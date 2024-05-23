using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCVillager : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public SceneTransition sceneTransition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        // Set the interaction flag to true when the dialog starts
        sceneTransition.interacted = true;

        // Start the dialogue
        dialogueSystem.StartDialog();
    }
}
