using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float interactionRange = 2f;

    private bool isPickedUp = false;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!isPickedUp && Input.GetKeyDown(KeyCode.E))
        {
            // Check if the player is in range to pick up the object
            if (IsPlayerInRange())
            {
                PickUpObject();
            }
        }
    }

    private bool IsPlayerInRange()
    {
        // Calculate the distance between the player and the object
        float distance = Vector2.Distance(transform.position, player.transform.position);
        return distance <= interactionRange;
    }

    private void PickUpObject()
    {
        isPickedUp = true;
        // Disable rendering so the object is not visible
        GetComponent<SpriteRenderer>().enabled = false;
        print("Object picked up " + isPickedUp);
    }
}
