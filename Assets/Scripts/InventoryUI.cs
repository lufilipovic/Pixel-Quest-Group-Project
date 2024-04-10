using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // Reference to the inventory panel
    public GameObject inventorySlotPrefab; // Reference to the inventory slot prefab
    public Transform inventorySlotsParent; // Parent transform for the inventory slots
   //public Text itemNameText; // Reference to the text element to display item name

    private bool inventoryOpen = false; // Flag to track if the inventory is open

    private void Start()
    {
        // Disable the inventory panel initially
        inventoryPanel.SetActive(false);
    }

    private void Update()
    {
        // Check if the "i" key is pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Toggle the inventory panel
            inventoryOpen = !inventoryOpen;
            inventoryPanel.SetActive(inventoryOpen);

            // Update the UI when inventory is opened
            if (inventoryOpen)
                UpdateInventoryUI();
        }
    }

    private void UpdateInventoryUI()
    {

        // Populate the inventory UI with items
        List<Item> inventory = PickUp.GetInventory();
        foreach (Item item in inventory)
        {
            // Instantiate a slot for each item
            GameObject slot = Instantiate(inventorySlotPrefab, inventorySlotsParent);
            RectTransform slotRectTransform = slot.GetComponent<RectTransform>();

            // Display item icon in the slot
            slot.GetComponent<Image>().sprite = item.icon;
            // Pass item name to the slot
            Debug.Log("prefab: "+ inventorySlotPrefab.name);
            InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();
            if (inventorySlot != null)
            {
                inventorySlot.itemName = item.name;
            }
            else
            {
                Debug.LogError("InventorySlot component not found on inventory slot prefab.");
            }

        }
    }
}
