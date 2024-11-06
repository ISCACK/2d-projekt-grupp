using UnityEngine;
using UnityEngine.UI; // Needed for UI components

public class SignTrigger : MonoBehaviour
{
    public GameObject signUI; // Assign the parent UI GameObject that holds text and/or image as children

    private void Start()
    {
        // Ensure the UI GameObject is initially hidden
        signUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Show the entire UI GameObject when the Player collides with the Sign
            signUI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Hide the entire UI GameObject when the Player exits the Sign's collider
            signUI.SetActive(false);
        }
    }
}
