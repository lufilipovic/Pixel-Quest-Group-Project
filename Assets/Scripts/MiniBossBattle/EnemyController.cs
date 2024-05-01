using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public GameObject projectilePrefab; // Projectile prefab to be released by the enemy
    public float moveSpeed = 0.4f; // Speed at which the enemy moves
    public float projectileSpeed = 5f; // Speed of the enemy projectiles
    public Transform shootPoint; // Reference to the point from where projectiles will be shot

    private EdgeCollider2D[] edgeColliders; // Array to store all edge colliders in the scene
    public float projectileLifetime = 2.0f; // Lifetime of the projectiles in seconds

    void Start()
    {
        // Find all edge colliders in the scene
        edgeColliders = FindObjectsOfType<EdgeCollider2D>();
    }

    void Update()
    {
        // Check if player reference is assigned
        if (player != null)
        {
            // Calculate direction towards the player
            Vector3 direction = (player.position - transform.position).normalized;

            // Move towards the player slowly
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Constrain enemy movement within edge colliders
            foreach (EdgeCollider2D edgeCollider in edgeColliders)
            {
                ConstrainToEdgeCollider(edgeCollider);
            }

            // Release projectiles in four directions from the position of the enemy
            ReleaseProjectiles();
        }
        else
        {
            Debug.LogWarning("Player reference not assigned to EnemyController.");
        }
    }

    void ConstrainToEdgeCollider(EdgeCollider2D edgeCollider)
    {
        if (edgeCollider != null)
        {
            Vector2[] points = edgeCollider.points;

            for (int i = 0; i < points.Length - 1; i++)
            {
                Vector2 point1 = edgeCollider.transform.TransformPoint(points[i]);
                Vector2 point2 = edgeCollider.transform.TransformPoint(points[i + 1]);

                Vector2 closestPointOnEdge = MathUtility.ClosestPointOnLineSegment(point1, point2, transform.position);
                float distanceToEdge = Vector2.Distance((Vector2)transform.position, closestPointOnEdge);

                if (distanceToEdge < 0.1f) // Adjust this value to control how close the enemy can get to the edge
                {
                    // Move the enemy away from the edge
                    transform.position += ((Vector3)transform.position - (Vector3)closestPointOnEdge).normalized * 0.01f;
                }
            }
        }
    }

    void ReleaseProjectiles()
    {
        // Release projectiles from the shoot point in four directions
        ShootProjectile(Vector2.up);
        ShootProjectile(Vector2.down);
        ShootProjectile(Vector2.left);
        ShootProjectile(Vector2.right);
    }

    void ShootProjectile(Vector2 direction)
    {
        // Instantiate the projectile at the shoot point position
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);

        if (projectile != null)
        {
            Debug.Log("Projectile instantiated successfully at position: " + shootPoint.position);

            // Destroy the projectile after a certain lifetime
            Destroy(projectile, projectileLifetime);
            Debug.Log("Projectile will be destroyed after " + projectileLifetime + " seconds.");
        }
        else
        {
            Debug.LogError("Failed to instantiate projectile");
        }

        // Get the Rigidbody2D component of the projectile and set its velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found on projectile prefab.");
        }
    }

}

public static class MathUtility
{
    public static Vector2 ClosestPointOnLineSegment(Vector2 lineStart, Vector2 lineEnd, Vector2 point)
    {
        Vector2 lineDirection = lineEnd - lineStart;
        float lineLength = lineDirection.magnitude;
        lineDirection.Normalize();

        Vector2 pointDirection = point - lineStart;
        float projection = Vector2.Dot(pointDirection, lineDirection);

        if (projection <= 0)
        {
            return lineStart;
        }

        if (projection >= lineLength)
        {
            return lineEnd;
        }

        Vector2 projectionVector = lineDirection * projection;
        return lineStart + projectionVector;
    }
}







