using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;

    Inventory inventory;

    InventorySlot[] slots;

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void Update()
    {
        // Check if the "I" key is pressed
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Toggle the visibility of the inventory UI
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            // Update the UI
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
