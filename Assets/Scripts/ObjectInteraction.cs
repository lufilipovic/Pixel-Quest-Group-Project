using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInteraction : MonoBehaviour
{

    private GameObject player;
    public float interactionRange = 2f;
    public GameObject interactableObject; 
             

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Check if the player is in range to pick up the object
            if (IsPlayerInRange())
            {
                print("Hello I am " + interactableObject.name);
            }
        }
    }


    private bool IsPlayerInRange()
    {
        // Calculate the distance between the player and the object
        float distance = Vector2.Distance(transform.position, player.transform.position);
        return distance <= interactionRange;
    }

}
