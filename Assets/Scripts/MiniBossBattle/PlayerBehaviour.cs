using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public int maxLives = 3; // Maximum number of lives the player can have
    private int currentLives; // Current number of lives

    public Image[] hearts; // Array to hold heart images for the health bar

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives; // Set current lives to maximum lives at the start
        UpdateHealthBar(); // Update the health bar at the start
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
            UpdateHealthBar(); // Update the health bar after taking damage
        }
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

    // Method to update the health bar
    void UpdateHealthBar()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Activate or deactivate heart images based on the current number of lives
            hearts[i].gameObject.SetActive(i < currentLives);
        }
    }
}





