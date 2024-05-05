using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EdgeCollider2D>() != null)
        {
            Destroy(gameObject); // Destroy the projectile
        }
    }
}

