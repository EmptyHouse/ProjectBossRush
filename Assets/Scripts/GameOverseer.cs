using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Overseer object. Manages important references in the game
/// </summary>
public class GameOverseer : MonoBehaviour {
    #region enums
    public enum GameState
    {
        GamePlaying,
        MenuOpen,
    }

    #endregion enums

    #region static variables
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
    #endregion static variables

    #region main variables
    public Utilities.SceneField sceneToLoadOnQuitGame;
    public PlayerCharacterStats playerCharacterStats;
    public GameState currentGameState { get; private set; }


    public List<GameObject> listOfObjectsInDontDestroyOnLoad { get; private set; }
    #endregion main variables

    #region monobehaviour methods
    private void Awake()
    {
        
        instance = this;
        

        AddObjectToDontDestroyOnLoad(this.gameObject);
    }
    #endregion monobehaviour methods


    /// <summary>
    /// Sets the current game state of our game. Certain actions may need to be taken for certain states
    /// </summary>
    public void SetCurrentGameState(GameState gameStateToSet)
    {
        if (gameStateToSet == this.currentGameState)
        {
            Debug.LogWarning("You have set the state " + gameStateToSet.ToString() + " when it is already the current state");
            return;
        }
        this.currentGameState = gameStateToSet;
    }

    /// <summary>
    /// In some cases we will want to persist the objects that are persistent throughout different levels
    /// For example the in game UI and the game overseer should be persisted
    /// </summary>
    /// <param name="gameObjectToAddToDontDestroyOnLoad"></param>
    public void AddObjectToDontDestroyOnLoad(GameObject gameObjectToAddToDontDestroyOnLoad)
    {
        if (listOfObjectsInDontDestroyOnLoad == null)
        {
            listOfObjectsInDontDestroyOnLoad = new List<GameObject>();
        }
        DontDestroyOnLoad(gameObjectToAddToDontDestroyOnLoad);
        listOfObjectsInDontDestroyOnLoad.Add(gameObjectToAddToDontDestroyOnLoad);
    }

    /// <summary>
    /// 
    /// </summary>
    public void DestroyAllGameObjectsInDontDestroyOnLoad()
    {
        if (listOfObjectsInDontDestroyOnLoad == null) return;

        foreach (GameObject objectToDestroy in listOfObjectsInDontDestroyOnLoad)
        {
            Destroy(objectToDestroy);
        }
    }

    public void QuitGameAndReturnToMainMenu()
    {
        DestroyAllGameObjectsInDontDestroyOnLoad();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoadOnQuitGame);
    }
}
