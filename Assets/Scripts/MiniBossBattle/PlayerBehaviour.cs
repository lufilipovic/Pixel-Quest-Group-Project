using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has a Rigidbody2D component
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        // Check if the collided object is a projectile and not an enemy
        if (rb != null && collision.gameObject.tag != "Enemy")
        {
            Destroy(collision.gameObject);
            print("Enemy projectile hit the player!");
        }
    }

    // This is called if the Collider on the game object has "Is Trigger" checked.
    // Then it doesn't physically react to hits but still detects them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("Player is hit!");
    }
}



