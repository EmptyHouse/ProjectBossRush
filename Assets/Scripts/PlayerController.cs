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
        Vector2 adjustedPlayerInput = AdjustPlayerInputBasedOnCamera(new Vector2(Input.GetAxisRaw(HORIZONTAL_AXIS), Input.GetAxisRaw(VERTICAL_AXIS)));
        characterStats.characterMovement.SetMovementInput(adjustedPlayerInput.x, adjustedPlayerInput.y);
    }

    /// <summary>
    /// Method to adjust the player's input based on the direction of the camera
    /// </summary>
    /// <returns></returns>
    private Vector2 AdjustPlayerInputBasedOnCamera(Vector2 originalPlayerInput)
    {
        Camera cam = GameOverseer.Instance.mainGameCamera;
        Vector3 playerInput3 = new Vector3(originalPlayerInput.x, 0, originalPlayerInput.y);
        Vector3 updatedInput = cam.transform.TransformDirection(playerInput3);
        return new Vector2(updatedInput.x, updatedInput.z);

    }
    #endregion monobehaviour methodss

}
