using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 2; // Changed space to allow only 2 items

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Inventory full. Cannot add more items.");
                return false;
            }
            items.Add(item);

            onItemChangedCallback?.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        onItemChangedCallback?.Invoke();
    }

    public bool HasItem(string itemName)
    {
        foreach (Item item in items)
        {
            if (item.name == itemName)
            {
                return true;
            }
        }
        return false;
    }

    public Item GetItem(string itemName)
    {
        foreach (Item item in items)
        {
            if (item.name == itemName)
            {
                return item;
            }
        }
        return null;
    }
}
