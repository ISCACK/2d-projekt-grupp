using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    // Drag your Text component here in the Inspector
    public Text messageText;

    void Start()
    {
        // Hide the text initially if it's assigned
        if (messageText != null)
        {
            messageText.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (messageText != null)
            {
                messageText.enabled = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (messageText != null)
            {
                messageText.enabled = false;
            }
        }
    }
}
