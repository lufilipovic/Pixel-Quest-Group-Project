using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private GameObject player; // Reference to the player GameObject
    public float interactionRange = 2f; // Range within which the player can interact with the object
    public GameObject interactableObject; // The interactable object
    public GameObject interactionPanel; // Reference to the UI Panel for interaction

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Find the player GameObject
        interactionPanel.SetActive(false); // Ensure the interaction panel is initially inactive
    }

    private void Update()
    {
        // Check if the 'E' key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the interaction panel
            if (interactionPanel.activeSelf)
            {
                interactionPanel.SetActive(false); // Close the interaction panel if it's already open
            }
            else if (IsPlayerInRange())
            {
                Debug.Log("Hello I am " + interactableObject.name); // Log interaction with the object
                interactionPanel.SetActive(true); // Show the interaction panel if the player is in range
            }
        }
    }

    // Check if the player is within interaction range of the object
    private bool IsPlayerInRange()
    {
        // Calculate the distance between the object and the player
        float distance = Vector3.Distance(transform.position, player.transform.position);
        return distance <= interactionRange; // Return true if player is within interaction range
    }

    // Method to close the interaction panel
    public void ClosePanel()
    {
        interactionPanel.SetActive(false); // Hide the interaction panel
    }
}
