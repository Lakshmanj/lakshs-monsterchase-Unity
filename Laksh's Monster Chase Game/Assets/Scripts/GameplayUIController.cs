using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{



    public void RestartGame()
    {
        // SceneManager.LoadScene("Gameplay");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            // This will reload the current scene that we are in.
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu"); // must match the name of the main menu scene.
    }
}
