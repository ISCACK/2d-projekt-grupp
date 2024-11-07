using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSoundScript : MonoBehaviour
{
    public AudioClip dashClip;         // Drag your dash audio file here in the Inspector
    public KeyCode dashKey = KeyCode.LeftShift; // Key to trigger the dash sound (default is Left Shift)

    private AudioSource dashAudio;
    private bool canPlayDashSound = true; // Controls whether the dash sound can play

    private void Start()
    {
        // Create an AudioSource component and set it up with the dash clip
        dashAudio = gameObject.AddComponent<AudioSource>();
        dashAudio.clip = dashClip;
        dashAudio.playOnAwake = false;
    }

    private void Update()
    {
        // Check if the dash key is pressed and dash sound can play
        if (Input.GetKeyDown(dashKey) && canPlayDashSound)
        {
            PlayDashSound();
            canPlayDashSound = false; // Prevents the sound from playing again immediately
            StartCoroutine(DashCooldown());
        }
    }

    private void PlayDashSound()
    {
        if (dashClip != null)
        {
            dashAudio.Play();
        }
    }

    // Cooldown for resetting dash sound ability
    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(1f); // Dash cooldown is now 1 second
        canPlayDashSound = true;
    }
}
