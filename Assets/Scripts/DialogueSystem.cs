using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public CanvasRenderer panel;
    public TMP_Text textDisplay;
    public string[] dialogTextLines;
    public AudioClip typingSound;  // Add this line
    private AudioSource audioSource;  // Add this line
    private int index = 0;

    private bool isTyping = false;
    private bool activeDialog = false;
    private bool dialogueTriggered = false;

    //public SceneTransition sceneTransition;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  // Initialize the audio source
        ResetDialog();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && activeDialog)
        {
            ContinueDialog();
        }

        if (Input.GetKeyDown(KeyCode.X) && activeDialog)
        {
            SkipDialog();
        }
    }

    public void StartDialog()
    {
        Debug.Log("StartDialog called");

        if (dialogueTriggered)
        {
            return;
        }

        dialogueTriggered = true;
        ResetDialog();
        Time.timeScale = 0f;
        panel.gameObject.SetActive(true);
        activeDialog = true;
        StartCoroutine(Typing());
    }

    public void ContinueDialog()
    {
        if (isTyping) return;
        index += 1;

        if (index < dialogTextLines.Length)
        {
            StartCoroutine(Typing());
        }
        else
        {
            ResetDialog();
        }
    }

    public void SkipDialog()
    {
        Debug.Log("SkipDialog called");
        StopAllCoroutines();
        ResetDialog();
    }

    IEnumerator Typing()
    {
        isTyping = true;
        textDisplay.SetText("");
        foreach (char letter in dialogTextLines[index].ToCharArray())
        {
            textDisplay.text += letter;

            // Play the typing sound effect for each character
            if (typingSound != null)
            {
                audioSource.PlayOneShot(typingSound);
            }

            yield return new WaitForSecondsRealtime(0.01f);
        }
        isTyping = false;
    }

    private void ResetDialog()
    {
        Debug.Log("Resetting dialog");
        panel.gameObject.SetActive(false);
        index = 0;
        textDisplay.SetText("");
        Time.timeScale = 1f;
        activeDialog = false;
    }
}

