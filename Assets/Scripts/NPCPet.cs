using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPet : MonoBehaviour
{
    public Transform target; // Player's transform
    public float followDistance = 2f; // Desired distance between NPC and player
    public float speed = 2f; // Movement speed of the NPC

    private void Update()
    {
        // Check if the target (player) exists
        if (target != null)
        {
            // Calculate the direction from the NPC to the player
            Vector3 direction = target.position - transform.position;

            // Calculate the distance between the NPC and the player
            float distance = direction.magnitude;

            // Check if the distance is greater than the desired follow distance
            if (distance > followDistance)
            {
                // Calculate the desired position for the NPC to maintain the follow distance
                Vector3 desiredPosition = target.position - direction.normalized * followDistance;

                // Move towards the desired position
                transform.position = Vector3.MoveTowards(transform.position, desiredPosition, speed * Time.deltaTime);
            }
        }
    }
}
