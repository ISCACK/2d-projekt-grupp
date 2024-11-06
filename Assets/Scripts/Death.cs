using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private DeathCounterUI deathCounterUI;

    private void Start()
    {
        // Find the DeathCounterUI in the scene
        deathCounterUI = FindObjectOfType<DeathCounterUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Increment the death count
            deathCounterUI.IncrementDeathCount();

            // Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
