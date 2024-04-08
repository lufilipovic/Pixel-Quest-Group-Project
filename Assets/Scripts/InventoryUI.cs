using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel; // Reference to the inventory panel

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
        }
    }
}
