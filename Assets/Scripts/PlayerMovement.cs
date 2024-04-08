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

        // Freeze rotation along the Z-axis
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {

        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
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

