using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    #region const variables
    protected const float JOYSTICK_RUN_THRESHOLD = .65f;
    protected const float JOYSTICK_WALK_THRESHOLD = .15f;
    #endregion const variables

    #region main variables
    [Tooltip("The walk speed of our characters")]
    public float walkSpeed = 3;
    [Tooltip("The run speed of our character")]
    public float runSpeed = 7;
    [Tooltip("The acceleration of our character")]
    public float movementAcceleration = 20;

    public CharacterStats associatedCharacterStats { get; set; }
    private float horizontalInput;
    #endregion main variables

    #region monobehaviour methods
    protected virtual void Update()
    {
        UpdateMovementBasedOnInput();
    }
    #endregion monobehaviour methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="horizontalInput"></param>
    public void SetMovementInput(float horizontalInput)
    {
        this.horizontalInput = horizontalInput;
    }

    /// <summary>
    /// 
    /// </summary>
    protected virtual void UpdateMovementBasedOnInput()
    {
        float goalSpeed = 0;

        if (Mathf.Abs(horizontalInput) > JOYSTICK_RUN_THRESHOLD)
        {
            goalSpeed = Mathf.Sign(horizontalInput) * runSpeed;
        }
        else if (Mathf.Abs(horizontalInput) > JOYSTICK_WALK_THRESHOLD)
        {
            goalSpeed = Mathf.Sign(horizontalInput) * walkSpeed;
        }
        CustomPhysics2D rigid = associatedCharacterStats.rigid;

        float updatedX = Mathf.MoveTowards(rigid.velocity.x, goalSpeed, Time.deltaTime * movementAcceleration);
        rigid.velocity = new Vector2(updatedX, rigid.velocity.y);
    }

}
