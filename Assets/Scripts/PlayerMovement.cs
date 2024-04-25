using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 movementDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        rb.velocity = movementDirection * movementSpeed;

        // Check for screen edge collisions
        CheckScreenEdgeCollisions();
    }

    void CheckScreenEdgeCollisions()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Check left edge
        if (screenPosition.x <= 0)
        {
            Vector2 knockbackDirection = Vector2.right;
            StartCoroutine(AnimateKnockback(knockbackDirection));
        }
        // Check right edge
        else if (screenPosition.x >= screenWidth)
        {
            Vector2 knockbackDirection = Vector2.left;
            StartCoroutine(AnimateKnockback(knockbackDirection));
        }
        // Check bottom edge
        if (screenPosition.y <= 0)
        {
            Vector2 knockbackDirection = Vector2.up;
            StartCoroutine(AnimateKnockback(knockbackDirection));
        }
        // Check top edge
        else if (screenPosition.y >= screenHeight)
        {
            Vector2 knockbackDirection = Vector2.down;
            StartCoroutine(AnimateKnockback(knockbackDirection));
        }
    }

    IEnumerator AnimateKnockback(Vector2 direction)
    {

        // Stop player movement
        rb.velocity = Vector2.zero;

        // Wait for a short duration
        yield return new WaitForSeconds(0.2f);

        // Resume player movement
        rb.velocity = movementDirection * movementSpeed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var dialogScript = other.gameObject.GetComponent<DialogueSystem>();
        if (dialogScript)
        {
            dialogScript.StartDialog();
        }
    }
}






