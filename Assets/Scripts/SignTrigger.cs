using UnityEngine;
using UnityEngine.UI; // Use this if you're using the default Text component
// using TMPro; // Uncomment this if you're using TextMeshPro

public class SignTrigger : MonoBehaviour
{
    public Text signText; // Assign your UI Text component here
    // public TextMeshProUGUI signText; // Uncomment if using TextMeshPro

    private void Start()
    {
        // Ensure the text is initially hidden
        signText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Show the UI text when the Player collides with the Sign
            signText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Hide the UI text when the Player exits the Sign's collider
            signText.gameObject.SetActive(false);
        }
    }
}
