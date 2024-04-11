using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float interactionRange = 2f;
    public Item item;

    private GameObject player;
    private Inventory inventory;

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
