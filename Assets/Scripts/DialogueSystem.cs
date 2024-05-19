using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public CanvasRenderer panel;
    public TMP_Text textDisplay;
    public string[] dialogTextLines;
    private int index = 0;

    private bool isTyping = false;
    private bool activeDialog = false;
    private bool dialogueTriggered = false;  // Track if the dialogue has been triggered

    void Start()
    {
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

        // Check if the dialogue has already been triggered
        if (dialogueTriggered)
        {
            //Debug.Log("Dialogue already triggered");
            return;
        }

        // Set the flag to indicate that the dialogue has been triggered
        dialogueTriggered = true;

        ResetDialog();
        Time.timeScale = 0f;
        panel.gameObject.SetActive(true);
        activeDialog = true;
        StartCoroutine(Typing());
    }

    public void ContinueDialog()
    {
        //Debug.Log("ContinueDialog called");
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
        StopAllCoroutines();  // Stop any ongoing typing coroutine
        ResetDialog();        // Reset the dialogue system
    }

    IEnumerator Typing()
    {
        //Debug.Log("Typing coroutine started");
        isTyping = true;
        textDisplay.SetText("");
        foreach (char letter in dialogTextLines[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSecondsRealtime(0.02f);
        }
        isTyping = false;
        //Debug.Log("Typing coroutine finished");
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
