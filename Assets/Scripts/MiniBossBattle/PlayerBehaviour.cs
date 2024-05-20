using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    public int maxLives = 3; // Maximum number of lives the player can have
    private int currentLives; // Current number of lives

    public Image[] hearts; // Array to hold heart images for the health bar
    public AudioClip hitSound; // Sound effect to play when hit
    private AudioSource audioSource;

    public GameObject gameOverPanel;

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

    // Method to update the health bar
    void UpdateHealthBar()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Activate or deactivate heart images based on the current number of lives
            hearts[i].gameObject.SetActive(i < currentLives);
        }
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the triggered object has a Rigidbody2D component
        Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();

        // Check if the triggered object is a projectile and not an enemy
        if (rb != null && other.gameObject.CompareTag("EnemyProjectile"))
        {
            // Play the hit sound effect
            if (hitSound != null)
            {
                audioSource.PlayOneShot(hitSound);
            }
            else
            {
                Debug.LogWarning("Hit sound effect is not assigned.");
            }

            Destroy(other.gameObject);
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
            gameOverPanel.SetActive(true);
        }
    }
}








