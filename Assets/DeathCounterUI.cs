using UnityEngine;
using UnityEngine.UI;

public class DeathCounterUI : MonoBehaviour
{
    private Text deathCounterText;
    private int deathCount;

    private void Start()
    {
        deathCounterText = GetComponent<Text>();

        // Check if this is a new game launch (not a scene reload)
        if (!PlayerPrefs.HasKey("GameStarted"))
        {
            // This is a fresh game start, reset the death count
            PlayerPrefs.SetInt("DeathCount", 0);
            PlayerPrefs.SetInt("GameStarted", 1); // Mark the game as started
        }

        // Load the current death count
        deathCount = PlayerPrefs.GetInt("DeathCount", 0);
        UpdateDeathCounterText();
    }

    public void IncrementDeathCount()
    {
        // Increment the death count and save it
        deathCount++;
        PlayerPrefs.SetInt("DeathCount", deathCount);
        UpdateDeathCounterText();
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("GameStarted");
    }


    private void UpdateDeathCounterText()
    {
        deathCounterText.text = "Deaths: " + deathCount;
    }
}
