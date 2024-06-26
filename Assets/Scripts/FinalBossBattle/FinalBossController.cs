using UnityEngine;

public class FinalBossController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public float moveSpeed = 0.4f; // Speed at which the enemy moves
    public float projectileSpeed = 10f; // Speed of the projectile
    public float fireRate = 1f; // Rate of fire in shots per second
    public float followDistance = 7f; // Distance at which the enemy starts following the player
    public float stopDistance = 1f; // Distance at which the enemy stops following the player
    public float projectileLifetime = 1.5f;
    public AudioClip shootSound; // Sound effect to play when shooting
    private AudioSource audioSource;

    private EdgeCollider2D[] edgeColliders; // Array to store all edge colliders in the scene
    private bool isFollowingPlayer = false; // Flag to track if the enemy is following the player
    private float fireTimer = 0f; // Timer to control firing rate

    void Start()
    {
        // Find all edge colliders in the scene
        edgeColliders = FindObjectsOfType<EdgeCollider2D>();

        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is not found on this GameObject, add it
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check if player reference is assigned
        if (player != null)
        {
            // Calculate distance to the player
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            // Check if the player is within follow distance and not too close
            if (distanceToPlayer <= followDistance && distanceToPlayer > stopDistance)
            {
                isFollowingPlayer = true;
            }
            else if (distanceToPlayer <= stopDistance)
            {
                isFollowingPlayer = false;
            }

            // If the enemy is following the player, move towards the player
            if (isFollowingPlayer)
            {
                // Calculate direction towards the player
                Vector3 direction = (player.position - transform.position).normalized;

                // Move towards the player
                transform.position += direction * moveSpeed * Time.deltaTime;

                // Fire at the player
                fireTimer += Time.deltaTime;
                if (fireTimer >= 1f / fireRate)
                {
                    Fire();
                    fireTimer = 0f;
                }
            }

            // Constrain enemy movement within edge colliders
            foreach (EdgeCollider2D edgeCollider in edgeColliders)
            {
                ConstrainToEdgeCollider(edgeCollider);
            }
        }
        else
        {
            Debug.LogWarning("Player reference not assigned to EnemyController.");
        }
    }

    void ConstrainToEdgeCollider(EdgeCollider2D edgeCollider)
    {

    }


    void Fire()
    {
        // Play the shoot sound effect
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
        else
        {
            Debug.LogWarning("Shoot sound effect is not assigned.");
        }

        // Calculate the direction towards the player
        Vector3 shootDirection = (player.position - transform.position).normalized;

        // Instantiate the first projectile slightly offset to the right
        GameObject projectile1 = Instantiate(projectilePrefab, transform.position + Vector3.right * 0.3f, Quaternion.identity);
        Rigidbody2D rb1 = projectile1.GetComponent<Rigidbody2D>();
        if (rb1 != null)
        {
            rb1.velocity = shootDirection * projectileSpeed;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on projectile prefab.");
        }

        // Instantiate the second projectile slightly offset to the left
        GameObject projectile2 = Instantiate(projectilePrefab, transform.position + Vector3.left * 0.3f, Quaternion.identity);
        Rigidbody2D rb2 = projectile2.GetComponent<Rigidbody2D>();
        if (rb2 != null)
        {
            rb2.velocity = shootDirection * projectileSpeed;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on projectile prefab.");
        }

        Destroy(projectile1, projectileLifetime);
        Destroy(projectile2, projectileLifetime);
    }
}
