using UnityEngine;


public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game is exiting"); // This log will appear only in the editor.
    }
}

