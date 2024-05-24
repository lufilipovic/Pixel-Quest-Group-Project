using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    public string puzzleKeyName = "Puzzle Key";
    public string bossKeyName = "Boss Key";

    private Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance; // Get the singleton instance of the Inventory
    }

    private void Update()
    {
        // Check if the player is interacting with the chest (e.g., pressing the "E" key)
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInRange())
        {
            TryUnlockChest();
        }
    }

    private bool IsPlayerInRange()
    {
        // Assuming the player is tagged with "Player"
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            return distance <= 2f; // Adjust interaction range as needed
        }
        return false;
    }

    private void TryUnlockChest()
    {
        if (inventory.HasItem(puzzleKeyName) && inventory.HasItem(bossKeyName))
        {
            UnlockChest();
        }
        else
        {
            Debug.Log("You need both the Puzzle Key and the Boss Key to unlock this chest.");
        }
    }

    private void UnlockChest()
    {
        Debug.Log("Chest unlocked!");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        // Optionally, remove the keys from the inventory
        inventory.Remove(inventory.GetItem(puzzleKeyName));
        inventory.Remove(inventory.GetItem(bossKeyName));
    }
}
