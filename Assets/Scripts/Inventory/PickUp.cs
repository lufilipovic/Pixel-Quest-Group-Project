using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float interactionRange = 2f;
    public Item item;

    private GameObject player;
    private Inventory inventory;

    public SceneTransition sceneTransition;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = Inventory.instance; // Assign the Inventory singleton instance
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the player is in range to pick up the object
            if (IsPlayerInRange())
            {
                PickUpObject();
            }
        }
    }

    private bool IsPlayerInRange()
    {
        // Calculate the distance between the player and the object
        float distance = Vector2.Distance(transform.position, player.transform.position);
        return distance <= interactionRange;
    }

    private void PickUpObject()
    {
        // Add the item to the inventory
        if (inventory.Add(item))
        {
            // Display a message in the console
            //Debug.Log($"Picked up item: {item.name}");

            // Check if the picked-up item is the Puzzle Key
            if (item.name == "Puzzle Key")
            {
                sceneTransition.interacted = true;
                Debug.Log("Puzzle Key picked up.");
            }

            // Check if the picked - up item is the Boss Key
            if (item.name == "Boss Key")
            {
                sceneTransition.interacted = true;
                Debug.Log("Boss Key picked up.");
            }


            // Disable rendering so the object is not visible
            GetComponent<SpriteRenderer>().enabled = false;
            // Set the object as picked up
            item.isPickedUp = true;
        }
        else
        {
            Debug.Log("Inventory full. Cannot pick up item.");
        }
    }
}
