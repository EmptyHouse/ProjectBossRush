using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region const variables
    public const float JOYSTICK_WALK_THRESHOLD = .15f;
    public const float JOYSTICK_RUN_THRESHOLD = .60f;
    #endregion const variables
    #region main variables
    [Tooltip("The maximum speed that our character will move at when running")]
    public float runSpeed = 7;
    [Tooltip("The speed our character will move at while walking")]
    public float walkSpeed = 4;
    /// <summary>
    /// This is the acceleration our character will take to reach the goal speed
    /// </summary>
    public float movementAcceleration = 15;

    private float horizontalInput = 0;
    private float verticalInput = 0;
    #endregion main variables
    #region monoabehaviour methods
    private void Awake()
    {
        
    }

    private void OnValidate()
    {
        if (walkSpeed < 0)
        {
            walkSpeed = 0;
        }

        if (runSpeed < walkSpeed)
        {
            runSpeed = walkSpeed;
        }
    }
    #endregion monobeahviour methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetMovementInput(float x, float y)
    {
        horizontalInput = x;
        verticalInput = y;
    }
}
