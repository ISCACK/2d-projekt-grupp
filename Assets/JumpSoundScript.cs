using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSoundScript : MonoBehaviour
{
    public AudioClip jumpClip;     // Drag your jump audio file here in the Inspector
    public Transform groundCheck;  // Transform for ground check position
    public LayerMask groundLayer;  // LayerMask for ground layer

    private AudioSource jumpAudio;
    private bool isGrounded;
    private bool canPlayJumpSound = true; // Controls whether the jump sound can play

    private void Start()
    {
        // Create an AudioSource component and set it up with the jump clip
        jumpAudio = gameObject.AddComponent<AudioSource>();
        jumpAudio.clip = jumpClip;
        jumpAudio.playOnAwake = false;
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = IsGrounded();

        // Check if the jump button is pressed and the player is grounded
        if (Input.GetButtonDown("Jump") && isGrounded && canPlayJumpSound)
        {
            PlayJumpSound();
            canPlayJumpSound = false; // Prevents the sound from playing again mid-air
        }

        // Reset the ability to play the jump sound when the player lands
        if (isGrounded)
        {
            canPlayJumpSound = true;
        }
    }

    private bool IsGrounded()
    {
        // Perform ground check using OverlapCircle
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void PlayJumpSound()
    {
        if (jumpClip != null)
        {
            jumpAudio.Play();
        }
    }
}
