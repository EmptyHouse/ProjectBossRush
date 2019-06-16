using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region const variables
    public const string AXIS_HORIZONTAL = "Horizontal";
    public const string AXIS_VERTICAL = "Vertical";
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
    }
    #endregion monobehaivour methods
}
