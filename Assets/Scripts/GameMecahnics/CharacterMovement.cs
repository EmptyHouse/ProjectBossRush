using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class CharacterMovement : MonoBehaviour
{

    #region enum
    public enum Direction : byte
    {
        E = 0x00,
        NE = 0x01,
        N = 0x02,
        NW = 0x03,
        W = 0x04,
        SW = 0x05,
        S = 0x06,
        SE = 0x07,
    }
    #endregion enum

    #region const variables
    public const float JOYSTICK_WALK_THRESHOLD = .15f;
    public const float JOYSTICK_RUN_THRESHOLD = .65f;

    public const string ANIM_VERTICAL = "vInput";
    public const string ANIM_HORIZONTAL = "hInput";

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Projectile projectile = Instantiate(Overseer.Instance.Projectile, Overseer.Instance.ProjectileParentTransform, true).GetComponent<Projectile>();
            projectile.SetupProjectile(associatedCharacterStats, Direction.NE);
        }
    }


    #endregion monobehaviour methods

    private void SetDirectionBasedOnInput()
    {

    }

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

        associatedCharacterStats.anim.SetFloat(ANIM_HORIZONTAL, this.xInput);
        associatedCharacterStats.anim.SetFloat(ANIM_VERTICAL, this.yInput);
    }
}
