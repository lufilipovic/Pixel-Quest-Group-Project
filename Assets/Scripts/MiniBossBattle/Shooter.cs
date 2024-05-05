using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float projectileLifetime = 2f;

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MiniBossBattle" && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the projectile from the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate direction towards the mouse cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the projectile stays in 2D space
        Vector3 shootDirection = (mousePosition - transform.position).normalized;

        // Get the Rigidbody2D component of the projectile and set its velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = shootDirection * projectileSpeed;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on projectile prefab.");
        }

        // Destroy the projectile after a specified period of time
        Destroy(projectile, projectileLifetime);
    } 
}
















