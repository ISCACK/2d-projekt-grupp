using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void ChangeSceneByName(string name)
    {
        SceneManager.LoadScene(name);

    }

    public void QuitGameU()
    {
        Application.Quit();

        Debug.Log("Bombo Left");
    }


}