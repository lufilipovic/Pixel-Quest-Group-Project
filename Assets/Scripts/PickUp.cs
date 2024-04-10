using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float interactionRange = 2f;
    public string itemName; // Name of the item
    public Item item;

    private static List<Item> inventory = new List<Item>(); // Static list to hold picked up items
    private bool isPickedUp = false;
    private GameObject player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!isPickedUp && Input.GetKeyDown(KeyCode.E))
        {
            // Check if the player is in range to pick up the object
            if (IsPlayerInRange())
            {
                PickUpObject();
                PrintInventory(); // Print inventory each time something is picked up
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
        isPickedUp = true;
        // Disable rendering so the object is not visible
        GetComponent<SpriteRenderer>().enabled = false;
        inventory.Add(item); // Add the item to the inventory
        //print(itemName + " picked up");
    }

    // Static method to access the inventory from other scripts
    public static List<Item> GetInventory()
    {
        return inventory;
    }

    // Method to print inventory contents
    private void PrintInventory()
    {
        print("Inventory contents:");
        foreach (Item item in inventory)
        {
            print("- " + item);
        }
    }

    //public void UpdateUI()
    //{
    //    for(int i = 0; i < inventory.Count; i++)
    //    {

    //    }
    //}
}
