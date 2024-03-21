using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private bool isPickedUp = false;

    private void Update()
    {
        if (!isPickedUp && Input.GetKeyDown(KeyCode.E))
        {
            // Check if the player is in range (you might want to implement a range check)
            // For example, you can use Physics2D.OverlapCircle to detect if the player is nearby
            // or you can use a trigger collider on the player

            // For now, let's assume the player is in range to pick up the object
            PickUpObject();
        }
    }

    private void PickUpObject()
    {
        isPickedUp = true;
        // Disable rendering and collider so the object is not visible or interactable
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        print("Object picked up " + isPickedUp);

        // Add logic here to update player's inventory or save the state of the picked-up object
        // For example, you could add the object to a list in the player's inventory
    }
}
