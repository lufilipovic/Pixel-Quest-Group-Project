using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;
    //public GameObject gameManager;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            //Destroy(gameObject); // Destroy duplicate Inventory objects
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Persist the Inventory object across scene changes
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

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
