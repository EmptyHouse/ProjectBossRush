using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region const variables
    public const string AXIS_HORIZONTAL = "Horizontal";
    public const string AXIS_VERTICAL = "Vertical";
    public const string FIRE_BUTTON = "Fire3";
    #endregion const variables

    public PlayerCharacterStats characterStats { get; set; }

    #region monobehaviour methods
    private void Awake()
    {
    }

    private void Update()
    {
        float xInput = Input.GetAxisRaw(AXIS_HORIZONTAL);
        float yInput = Input.GetAxisRaw(AXIS_VERTICAL);

        characterStats.characterMovement.SetDirectionalInput(xInput, yInput);

        if (Input.GetButtonDown(FIRE_BUTTON))
        {
            characterStats.CombatHandler.HandleFireButton();
        }
    }
    #endregion monobehaivour methods
}
