using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile collides with an edge collider
        if (collision.GetComponent<EdgeCollider2D>() != null)
        {
            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}













