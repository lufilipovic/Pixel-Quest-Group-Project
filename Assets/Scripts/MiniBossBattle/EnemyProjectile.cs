using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EdgeCollider2D>() != null)
        {
            Destroy(gameObject); // Destroy the projectile
        }
    }
}




