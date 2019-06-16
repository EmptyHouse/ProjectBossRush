using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    #region const variables
    public const float JOYSTICK_WALK_THRESHOLD = .15f;
    public const float JOYSTICK_RUN_THRESHOLD = .65f;

    #endregion const variables
    private Rigidbody2D rigid
    {
        get
        {
            return associatedCharacterStats.rigid;
        }
    }
    public float maxRunSpeed = 10;
    public float maxWalkSpeed = 5;
    public float acceleration = 25;
    public CharacterStats associatedCharacterStats { get; set; }


    private float xInput;
    private float yInput;
    #region monobehavoiur methods
    private void Awake()
    {
        associatedCharacterStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        UpdateMovementBasedOnDirectionalInput();
    }
    #endregion monobehaviour methods

    private void UpdateMovementBasedOnDirectionalInput()
    {
        Vector2 inputVector = new Vector2(xInput, yInput);
        float goalSpeed = 0;
        if (inputVector.magnitude > JOYSTICK_RUN_THRESHOLD)
        {
            goalSpeed = maxRunSpeed;
        }
        else if (inputVector.magnitude > JOYSTICK_WALK_THRESHOLD)
        {
            goalSpeed = maxWalkSpeed;
        }

        Vector2 goalVelocity = inputVector.normalized * goalSpeed;
        rigid.velocity = goalVelocity;
    }

    public void SetDirectionalInput(float xInput, float yInput)
    {
        this.xInput = xInput;
        this.yInput = yInput;
    }
}
