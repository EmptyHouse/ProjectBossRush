using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverseer : MonoBehaviour
{

    public enum GameState
    {
        GamePlaying,
        MenuOpen,
    }

    private static GameOverseer instance;

    public static GameOverseer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<GameOverseer>();
            }
            return instance;
        }
    }


    private void Awake()
    {
        instance = this;
    }

    public void SetCurrentGameState(GameState gameState)
    {

    }

    public void AddObjectToDontDestroyOnLoad(GameObject gObject)
    {

    }

    public void QuitGameAndReturnToMainMenu()
    {

    }
}
