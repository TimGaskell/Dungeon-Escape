using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Opens up the Main Game. Need to change string value if scene is different
    /// </summary>
    public void StartButton() {

        SceneManager.LoadScene("Dungeon Escape Imported Map Editied");
    }

    /// <summary>
    /// Exits the application
    /// </summary>
    public void QuitButton() {

        Application.Quit();

    }
}
