using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float speed = 3f;
    private bool isFacingRight = true;
    private bool isMovingRight = true;

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
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        // Keep moving in a straight line, either right or left
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
        return Physics2D.OverlapCircle(weakpointCheck.position, 0.2f, playerLayer);
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
}