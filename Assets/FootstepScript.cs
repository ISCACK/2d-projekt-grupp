using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScript : MonoBehaviour
{
    public AudioClip footstepClip; // Drag the footstep audio file here in the Inspector
    public Transform groundCheck;  // Transform for ground check position
    public LayerMask groundLayer;  // LayerMask for ground layer

    private AudioSource footstepAudio;
    private bool isGrounded;

    private void Start()
    {
        // Create an AudioSource component and set it up with the footstep clip
        footstepAudio = gameObject.AddComponent<AudioSource>();
        footstepAudio.clip = footstepClip;
        footstepAudio.loop = true; // Set to loop so footsteps continue while moving
        footstepAudio.playOnAwake = false;
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = IsGrounded();

        // Check for horizontal movement input and grounded status
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalMovement) > 0.1f && isGrounded)
        {
            PlayFootsteps();
        }
        else
        {
            StopFootsteps();
        }
    }

    private bool IsGrounded()
    {
        // Perform ground check using OverlapCircle
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void PlayFootsteps()
    {
        if (footstepClip != null && !footstepAudio.isPlaying)
        {
            footstepAudio.Play();
        }
    }

    private void StopFootsteps()
    {
        if (footstepAudio.isPlaying)
        {
            footstepAudio.Stop();
        }
    }
}
