using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [SerializeField]
    private GameObject[] players;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this; // this will ensure that if the instance is null, it will call upon
                             //      getting the instance of this class.
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }


    }


    // We unsubscribe or subscribe to events
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        // We are subscribing to the sceneloaded with our onlevelfinishedloading function.
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Gameplay")
        {
            Instantiate(players[CharIndex]);
            // We are setting that value for the CharIndex to be equal to
            //  GameManager.instance.CharIndex = selectedPlayer;

            // this fixes the earlier issue we had with the player being instantiated before we needed it to.
            // this will provide enough time so that the game won't throw a null reference error.
        }

    }

} // Class
