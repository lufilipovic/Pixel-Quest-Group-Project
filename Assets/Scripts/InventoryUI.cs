using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // Reference to the inventory panel
    public GameObject inventorySlotPrefab; // Reference to the inventory slot prefab
    public Transform inventorySlotsParent; // Parent transform for the inventory slots
    //public GameObject backgroundPanelPrefab; // Reference to the background panel prefab

    private bool inventoryOpen = false; // Flag to track if the inventory is open
    private List<GameObject> instantiatedSlots = new List<GameObject>(); // Track instantiated slots

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
            else
                ClearInventoryUI(); // Clear inventory UI when closing inventory
        }
    }

    private void ClearInventoryUI()
    {
        // Destroy all instantiated slots
        foreach (GameObject slot in instantiatedSlots)
        {
            Destroy(slot);
        }
        // Clear the list
        instantiatedSlots.Clear();
    }

    private void UpdateInventoryUI()
    {
        // Clear existing inventory slots
        ClearInventoryUI();

        // Populate the inventory UI with items
        List<Item> inventory = PickUp.GetInventory();
        foreach (Item item in inventory)
        {
            // Check if the item has been picked up
            if (item.isPickedUp)
            {
                // Instantiate a slot for each item
                GameObject slot = Instantiate(inventorySlotPrefab, inventorySlotsParent);
                instantiatedSlots.Add(slot); // Add instantiated slot to the list
                RectTransform slotRectTransform = slot.GetComponent<RectTransform>();

                // Display item icon in the slot
                slot.GetComponent<Image>().sprite = item.icon;

                // Instantiate the background panel for the slot
                //GameObject backgroundPanel = Instantiate(backgroundPanelPrefab, slot.transform);

                // Pass references to the background panel and item name to the slot
                InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();
                if (inventorySlot != null)
                {
                    //inventorySlot.backgroundPanel = backgroundPanel;
                    inventorySlot.itemName = item.name;
                    print(item.name);
                }
                else
                {
                    Debug.LogError("InventorySlot component not found on inventory slot prefab.");
                }
            }
        }
    }
}
