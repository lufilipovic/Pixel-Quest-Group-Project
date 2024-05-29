using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance; // Singleton instance of the Inventory class

    void Awake()
    {
        // Ensure only one instance of Inventory exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy this instance if another instance already exists
            return;
        }

        instance = this; // Set this instance as the singleton instance
        DontDestroyOnLoad(gameObject); // Make this instance persistent across scene loads
    }

    #endregion

    public delegate void OnItemChanged(); // Delegate for item change events
    public OnItemChanged onItemChangedCallback; // Callback for item change events

    public int space = 2; // Maximum number of items the inventory can hold

    public List<Item> items = new List<Item>(); // List to hold the items in the inventory

    public bool Add(Item item)
    {
        // Add an item to the inventory if it is not a default item
        if (!item.isDefaultItem)
        {
            // Check if the inventory is full
            if (items.Count >= space)
            {
                Debug.Log("Inventory full. Cannot add more items."); // Log a message if the inventory is full
                return false; // Return false indicating the item could not be added
            }
            items.Add(item); // Add the item to the inventory

            onItemChangedCallback?.Invoke(); // Invoke the item change callback if it is set
        }

        return true; // Return true indicating the item was added successfully
    }

    public void Remove(Item item)
    {
        // Remove an item from the inventory
        items.Remove(item); // Remove the specified item from the inventory
        onItemChangedCallback?.Invoke(); // Invoke the item change callback if it is set
    }

    public bool HasItem(string itemName)
    {
        // Check if an item with the specified name exists in the inventory
        foreach (Item item in items)
        {
            if (item.name == itemName)
            {
                return true; // Return true if the item is found
            }
        }
        return false; // Return false if the item is not found
    }

    public Item GetItem(string itemName)
    {
        // Get an item with the specified name from the inventory
        foreach (Item item in items)
        {
            if (item.name == itemName)
            {
                return item; // Return the item if found
            }
        }
        return null; // Return null if the item is not found
    }
}
