using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Transform transitionPoint; // Specific point in the next scene where the player will appear
    public bool interacted = false; // Flag to check if the player has interacted with the NPCVillager

    public GameObject errorPanel; // UI panel to show error messages

    private void Start()
    {
        errorPanel.SetActive(false); // Ensure the error panel is hidden at the start
    }

    // Method called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Check if the player has interacted with the NPCVillager
            if (interacted)
            {
                // Load the next scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                // Move the player to the transition point in the next scene
                if (transitionPoint != null)
                {
                    other.transform.position = transitionPoint.position;
                }
            }
            else
            {
                // Show the error panel if the player has not interacted with the NPCVillager
                errorPanel.SetActive(true);
            }
        }
    }

    // Method to close the error panel
    public void closePanel()
    {
        errorPanel.SetActive(false); // Hide the error panel
    }
}
