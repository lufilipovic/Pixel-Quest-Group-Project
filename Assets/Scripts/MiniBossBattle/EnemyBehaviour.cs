using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public int maxLives = 3; // Maximum number of lives the enemy can have
    private int currentLives; // Current number of lives

    public Image[] hearts; // Array to hold heart images for the health bar
    public AudioClip hitSound; // Sound effect to play when hit
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives; // Set current lives to maximum lives at the start
        UpdateHealthBar(); // Update the health bar at the start

        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is not found on this GameObject, add it
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with a player projectile
        if (collision.CompareTag("PlayerProjectile"))
        {
            print("Enemy is hit!");
            // Play the hit sound effect
            if (hitSound != null)
            {
                audioSource.PlayOneShot(hitSound);
            }
            else
            {
                Debug.LogWarning("Hit sound effect is not assigned.");
            }

            // For player projectiles, decrease the current lives
            TakeDamage();
            Destroy(collision.gameObject); // Destroy the projectile
            UpdateHealthBar(); // Update the health bar after taking damage
        }
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










