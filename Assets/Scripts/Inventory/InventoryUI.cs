using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent; // Parent transform containing the inventory slots
    public GameObject inventoryUI; // The inventory UI GameObject

    Inventory inventory; // Reference to the player's inventory

    InventorySlot[] slots; // Array of inventory slots

    void Start()
    {
        inventory = Inventory.instance; // Get the singleton instance of the Inventory
        inventory.onItemChangedCallback += UpdateUI; // Subscribe to the onItemChangedCallback to update the UI

        slots = itemsParent.GetComponentsInChildren<InventorySlot>(); // Get all InventorySlot components in the itemsParent
    }

    void Update()
    {
        // Check if the "I" key is pressed to toggle the inventory UI
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf); // Toggle the active state of the inventory UI
            UpdateUI(); // Update the UI to reflect the current inventory
        }
    }

    // Update the inventory UI to match the current state of the inventory
    void UpdateUI()
    {
        // Loop through each slot and assign items or clear the slot
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]); // Add the item to the slot if within inventory range
            }
            else
            {
                slots[i].ClearSlot(); // Clear the slot if there is no corresponding item in the inventory
            }
        }
    }
}
