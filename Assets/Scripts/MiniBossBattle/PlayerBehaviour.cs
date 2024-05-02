using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int maxLives = 3; // Maximum number of lives the player can have
    private int currentLives; // Current number of lives

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives; // Set current lives to maximum lives at the start
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
            TakeDamage(); // Decrease player lives
        }
    }

    // This is called if the Collider on the game object has "Is Trigger" checked.
    // Then it doesn't physically react to hits but still detects them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    // Method to handle taking damage and checking for destruction
    void TakeDamage()
    {
        currentLives--; // Decrease the current lives
        if (currentLives <= 0)
        {
            // If lives reach zero or below, destroy the player object
            Destroy(gameObject);
            // You might want to add some game over logic here as well
        }
    }
}




