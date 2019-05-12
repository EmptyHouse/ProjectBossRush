using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region main variables
    [Tooltip("The walk speed of our characters")]
    public float walkSpeed = 3;
    [Tooltip("The run speed of our character")]
    public float runSpeed = 7;
    [Tooltip("The acceleration of our character")]
    public float movementAcceleration = 20;

    private CharacterStats associatedCharacterStats;
    #endregion main variables




    protected virtual void UpdateMovementBasedOnInput()
    {

    }

}
