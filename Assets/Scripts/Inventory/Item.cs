using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    // The name of the item
    new public string name = "New Item";

    // The icon representing the item
    public Sprite icon = null;

    // Determine if the item has been picked up
    public bool isPickedUp = false;

    // Determine if the item is a default item
    public bool isDefaultItem = false;

    // Virtual method to define the behavior when the item is used
    public virtual void Use()
    {
        // Log the item's usage
        Debug.Log("Using " + name);
    }
}
