using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint; // Reference to the point from where projectiles will be shot

    public float projectileSpeed = 10f;
    public float projectileLifetime = 2f; // Lifetime of the projectile in seconds

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Calculate the direction towards the mouse cursor
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the projectile stays in 2D space
        Vector3 shootDirection = (mousePosition - shootPoint.position).normalized;

        // Instantiate the projectile from the shootPoint position
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

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










