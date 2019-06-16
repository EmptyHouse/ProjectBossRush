using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Extension of the character stats script that handles special functionality for the player
/// </summary>
public class PlayerCharacterStats : CharacterStats
{

    public PlayerController playerController { get; private set; }
    #region monobehaviour methods
    protected override void Awake()
    {
        base.Awake();
        playerController = GetComponent<PlayerController>();
        playerController.characterStats = this;

    }


    #endregion monobehaviour methods
}
