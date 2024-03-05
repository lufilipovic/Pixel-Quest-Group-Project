using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; // Speed of the player movement
    public float boundaryPadding = 0.5f; // Padding to keep the player within the screen bounds

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Disable gravity
    }

    void FixedUpdate()
    {
        // Get input for movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * speed * Time.deltaTime;

        // Calculate new position
        Vector2 newPosition = rb.position + movement;

        // Keep the player within the screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x,
                                     Camera.main.ScreenToWorldPoint(Vector3.zero).x + boundaryPadding,
                                     Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x - boundaryPadding);
        newPosition.y = Mathf.Clamp(newPosition.y,
                                     Camera.main.ScreenToWorldPoint(Vector3.zero).y + boundaryPadding,
                                     Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y - boundaryPadding);

        // Move the player
        rb.MovePosition(newPosition);
    }
}
