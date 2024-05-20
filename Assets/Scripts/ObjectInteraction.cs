using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{
    private GameObject player;
    public float interactionRange = 2f;
    public GameObject interactableObject;
    public GameObject interactionPanel; // Reference to the UI Panel

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interactionPanel.SetActive(false); // Ensure the panel is initially inactive
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interactionPanel.activeSelf)
            {
                interactionPanel.SetActive(false); // Close the interaction panel if it's already open
            }
            else if (IsPlayerInRange())
            {
                print("Hello I am " + interactableObject.name);
                interactionPanel.SetActive(true); // Show the interaction panel if it's not open and the player is in range
            }
        }
    }

    private bool IsPlayerInRange()
    {
        // Calculate the distance between the player and the object
        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance <= interactionRange;
    }

    public void ClosePanel()
    {
        interactionPanel.SetActive(false); // Hide the interaction panel
    }
}
