using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon; // Reference to the UI Image component for displaying the item's icon
    Item item; // The item assigned to this slot

    // Method to add an item to this inventory slot
    public void AddItem(Item newItem)
    {
        item = newItem; // Assign the new item to the slot

        // Update the icon if the item and icon are not null
        if (item != null && icon != null)
        {
            icon.sprite = item.icon; // Set the icon's sprite to the item's icon
            icon.enabled = true; // Enable the icon to make it visible
        }
    }

    // Method to clear the item from this inventory slot
    public void ClearSlot()
    {
        item = null; // Clear the item reference

        // Clear the icon if the icon is not null
        if (icon != null)
        {
            icon.sprite = null; // Remove the sprite from the icon
            icon.enabled = false; // Disable the icon to make it invisible
        }
    }

    // Method called when the remove button is pressed
    public void OnRemoveButton()
    {
        Inventory.instance.Remove(item); // Remove the item from the inventory
    }

    // Method to use the item in this slot
    public void UseItem()
    {
        if (item != null)
        {
            item.Use(); // Call the item's Use method
        }
    }
}
