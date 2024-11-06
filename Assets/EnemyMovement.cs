using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 3f;
    private bool isFacingRight = true;
    private bool isMovingRight = true;
    private float bounce = 100f; // Bounce force for the player

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform flipCheck;
    [SerializeField] private Transform weakpointCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask flipLayer;
    [SerializeField] private LayerMask playerLayer;

    void Update()
    {
        // Check if enemy needs to flip direction
        if (IsAtFlipPoint())
        {
            Flip();
        }

        // Check if the enemy's weak point was hit
        if (IsWeakpointHit())
        {
            Debug.Log("Weak point hit by player! Applying bounce.");

            // Apply the jump pad effect to the player before destroying the enemy
            ApplyBounceToPlayer();

            // Destroy the enemy
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // Move in a straight line, either right or left
        rb.velocity = new Vector2((isMovingRight ? 1 : -1) * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        // Checks if the enemy is on the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsAtFlipPoint()
    {
        // Checks if the enemy is at a flip point, to reverse its direction
        return Physics2D.OverlapCircle(flipCheck.position, 0.2f, flipLayer);
    }

    private bool IsWeakpointHit()
    {
        // Checks if the player's ground check overlaps with the enemy's weak point
        bool hit = Physics2D.OverlapCircle(weakpointCheck.position, 0.2f, playerLayer);

        if (hit)
        {
            Debug.Log("Player detected at weak point!");
        }

        return hit;
    }

    private void Flip()
    {
        // Flip the direction the enemy is moving
        isMovingRight = !isMovingRight;

        // Flip the enemy's sprite by inverting the X scale
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void ApplyBounceToPlayer()
    {
        // Find the player object using the overlap circle on the weak point
        Collider2D playerCollider = Physics2D.OverlapCircle(weakpointCheck.position, 0.2f, playerLayer);

        // If the player collider is detected, apply a bounce force
        if (playerCollider != null)
        {
            Rigidbody2D playerRb = playerCollider.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Apply an upward bounce force to the player
                Debug.Log("Applying bounce force to player!");
                playerRb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            }
        }
    }
}
