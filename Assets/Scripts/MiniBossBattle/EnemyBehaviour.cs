using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int maxLives = 3; // Maximum number of lives the enemy can have
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
        
    }

    // This is called if the Collider on the game object has "Is Trigger" checked.
    // Then it doesn't physically react to hits but still detects them
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Enemy is hit!");
        // For triggers, decrease the current lives
        TakeDamage();
        Destroy(collision.gameObject); // Destroy the projectile
    }

    // Method to handle taking damage and checking for destruction
    void TakeDamage()
    {
        currentLives--; // Decrease the current lives
        if (currentLives <= 0)
        {
            // If lives reach zero or below, destroy the enemy object
            Destroy(gameObject);
        }
    }
}

