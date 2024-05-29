using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    public string puzzleKeyName = "Puzzle Key"; // Name of the puzzle key required to unlock the chest
    public string bossKeyName = "Boss Key";     // Name of the boss key required to unlock the chest

    private Inventory inventory; // Reference to the player's inventory

    private void Start()
    {
        inventory = Inventory.instance; // Get the singleton instance of the Inventory at the start
    }

    private void Update()
    {
        // Check if the player is pressing the "E" key to interact with the chest and if they are in range
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
        {
            TryUnlockChest(); // Attempt to unlock the chest if conditions are met
        }
    }

    private bool IsPlayerInRange()
    {
        // Check if the player is within a certain range of the chest
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Find the player object by tag
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position); // Calculate distance to player
            return distance <= 2f; // Return true if the player is within 2 units distance
        }
        return false; // Return false if player is not found
    }

    private void TryUnlockChest()
    {
        // Check if the player has both required keys in their inventory
        if (inventory.HasItem(puzzleKeyName) && inventory.HasItem(bossKeyName))
        {
            UnlockChest(); // Unlock the chest if both keys are present
        }
        else
        {
            Debug.Log("You need both the Puzzle Key and the Boss Key to unlock this chest."); // Log that the player needs both keys
        }
    }

    private void UnlockChest()
    {
        Debug.Log("Chest unlocked!"); // Log chest unlock event

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Load the next scene

        // Optionally, remove the keys from the inventory
        inventory.Remove(inventory.GetItem(puzzleKeyName)); // Remove the puzzle key from inventory
        inventory.Remove(inventory.GetItem(bossKeyName));  // Remove the boss key from inventory
    }
}
