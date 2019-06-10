using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An extension of the the CharacterStats class, but this will contain references that are only relevant to the player
/// </summary>
public class PlayerCharacterStats : CharacterStats {
    /// <summary>
    /// This is the primary camera that is following our player
    /// </summary>
    public CameraFollow playerCamera { get; set; }

    protected void Start()
    {
        //GameOverseer.Instance.playerCharacterStats = this;
    }
}
