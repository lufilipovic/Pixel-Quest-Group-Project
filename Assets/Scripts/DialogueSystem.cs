using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public CanvasRenderer panel; // The panel that displays the dialogue
    public TMP_Text textDisplay; // The text component to show the dialogue lines
    public string[] dialogTextLines; // Array of dialogue lines to be displayed
    public AudioClip typingSound; // Sound effect for typing
    private AudioSource audioSource; // AudioSource component for playing sound effects
    private int index = 0; // Index to keep track of the current dialogue line

    private bool isTyping = false; // Flag to indicate if typing animation is in progress
    private bool activeDialog = false; // Flag to indicate if dialogue is active
    private bool dialogueTriggered = false; // Flag to ensure dialogue is triggered only once

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Initialize the AudioSource component
        ResetDialog(); // Initialize the dialogue system
    }

    void Update()
    {
        // Continue dialogue when 'E' key is pressed and dialogue is active
        if (Input.GetKeyDown(KeyCode.E) && activeDialog)
        {
            ContinueDialog();
        }

        // Skip dialogue when 'X' key is pressed and dialogue is active
        if (Input.GetKeyDown(KeyCode.X) && activeDialog)
        {
            SkipDialog();
        }
    }

    // Method to start the dialogue
    public void StartDialog()
    {
        Debug.Log("StartDialog called");

        // Prevent dialogue from starting multiple times
        if (dialogueTriggered)
        {
            return;
        }

        dialogueTriggered = true; // Set dialogue as triggered
        ResetDialog(); // Reset dialogue settings
        Time.timeScale = 0f; // Pause the game
        panel.gameObject.SetActive(true); // Show the dialogue panel
        activeDialog = true; // Set dialogue as active
        StartCoroutine(Typing()); // Start typing the first line
    }

    // Method to continue to the next dialogue line
    public void ContinueDialog()
    {
        // Do nothing if typing animation is still in progress
        if (isTyping) return;

        index += 1; // Move to the next dialogue line

        // If there are more lines, continue typing them
        if (index < dialogTextLines.Length)
        {
            StartCoroutine(Typing());
        }
        else
        {
            ResetDialog(); // Reset the dialogue when all lines are finished
        }
    }

    // Method to skip the current dialogue
    public void SkipDialog()
    {
        Debug.Log("SkipDialog called");
        StopAllCoroutines(); // Stop the typing animation
        ResetDialog(); // Reset the dialogue
    }

    // Coroutine to animate typing the dialogue
    IEnumerator Typing()
    {
        isTyping = true; // Set typing flag
        textDisplay.SetText(""); // Clear the text display

        // Type each character one by one
        foreach (char letter in dialogTextLines[index].ToCharArray())
        {
            textDisplay.text += letter; // Add character to the text display

            // Play typing sound effect for each character
            if (typingSound != null)
            {
                audioSource.PlayOneShot(typingSound);
            }

            yield return new WaitForSecondsRealtime(0.01f); // Wait before typing the next character
        }
        isTyping = false; // Reset typing flag
    }

    // Method to reset the dialogue settings
    private void ResetDialog()
    {
        Debug.Log("Resetting dialog");
        panel.gameObject.SetActive(false); // Hide the dialogue panel
        index = 0; // Reset the dialogue index
        textDisplay.SetText(""); // Clear the text display
        Time.timeScale = 1f; // Resume the game
        activeDialog = false; // Set dialogue as inactive
        dialogueTriggered = false; // Reset dialogue triggered flag
    }
}
