using UnityEngine;
using UnityEngine.UI;

public class ShowTextOnSign : MonoBehaviour
{
    private Text signText;

    private void Start()
    {
        // Get the Text component attached to this GameObject
        signText = GetComponent<Text>();

        // Initially hide the text
        signText.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player and it's colliding with the "Sign"
        if (other.CompareTag("Player") && IsTouchingSign(other))
        {
            // Show the text
            signText.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Hide the text when the player exits the trigger with the sign
        if (other.CompareTag("Player"))
        {
            signText.enabled = false;
        }
    }

    private bool IsTouchingSign(Collider2D playerCollider)
    {
        // Check for a collision with any object tagged as "Sign"
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerCollider.transform.position, 0.1f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Sign"))
            {
                return true;
            }
        }

        return false;
    }
}
