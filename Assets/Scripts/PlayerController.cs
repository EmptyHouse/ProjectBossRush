using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class PlayerController : MonoBehaviour {
    #region const inputs
    public const string PAUSE_GAME_INPUT = "Pause";
    public const string HORIZONTAL_AXIS = "Horizontal";
    public const string VERTICAL_AXIS = "Vertical";

    public const string MELEE_INPUT = "Melee";
    public const string PROJECTILE_INPUT = "FireProjectile";
    public const string JUMP_INPUT = "Jump";
    #endregion const inputs
    private PlayerCharacterStats characterStats;
    #region monobehaviour methods
    private void Awake()
    {
        characterStats = GetComponent<PlayerCharacterStats>();
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw(HORIZONTAL_AXIS);
        float yInput = Input.GetAxisRaw(VERTICAL_AXIS);


        characterStats.characterMovement.SetDirectionalInput(xInput, yInput);
    }
    #endregion monobehaviour methodss

}
