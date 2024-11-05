using UnityEngine;
using UnityEngine.UI;

public class DisplayTextUIOnTrigger : MonoBehaviour
{
    public GameObject triggerZone; // Drag the trigger collider GameObject here
    private Text displayText;

    private void Start()
    {
        // Get the Text component on this GameObject
        displayText = GetComponent<Text>();

        // Initially hide the text
        displayText.enabled = false;
    }

    // This method will be called by the TriggerZone script
    public void SetTextVisibility(bool isVisible)
    {
        displayText.enabled = isVisible;
    }
}
