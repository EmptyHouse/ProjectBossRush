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
    private SpriteRenderer associatedSpriteRender;
    [Tooltip("")]
    private Rigidbody rigid;
    private float horizontalInput = 0;
    private float verticalInput = 0;
    /// <summary>
    /// 
    /// </summary>
    public CharacterStats associatedCharacterStats { get; set; }

    #endregion main variables
    #region monoabehaviour methods
    private void Awake()
    {
        associatedSpriteRender = GetComponentInChildren<SpriteRenderer>();
        rigid = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        UpdateMovementBasedOnInput();
    }

    protected virtual void LateUpdate()
    {
        
    }

    protected virtual void OnValidate()
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

    /// <summary>
    /// 
    /// </summary>
    protected virtual void UpdateMovementBasedOnInput()
    {
        Vector2 inputVec = new Vector2(horizontalInput, verticalInput);
        float mag = inputVec.magnitude;

        float goalSpeed = 0;
        if (mag > JOYSTICK_RUN_THRESHOLD)
        {
            goalSpeed = runSpeed;
        }
        else if (mag > JOYSTICK_WALK_THRESHOLD)
        {
            goalSpeed = walkSpeed;
        }
        //Vector2 updatedVectorSpeed = Vector2.MoveTowards(new Vector2(rigid.velocity.x, rigid.velocity.z), , Time.deltaTime * movementAcceleration);
        Vector2 updatedVectorSpeed = inputVec.normalized * goalSpeed;
        rigid.velocity = new Vector3(updatedVectorSpeed.x, 0, updatedVectorSpeed.y);
    }

    #region sprite methods
    /// <summary>
    /// 
    /// </summary>
    public void SetSpriteInDirectionBasedOnInput()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetSpriteAnimator()
    {

    }


    #endregion sprite methods
}
