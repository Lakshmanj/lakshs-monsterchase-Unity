using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        int selectedPlayer =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        // Make sure everything within the array is a int value, so that this will convert the string to
        //  an int.

         
        GameManager.instance.CharIndex = selectedPlayer;

        SceneManager.LoadScene("Gameplay");

    }


} // Class
