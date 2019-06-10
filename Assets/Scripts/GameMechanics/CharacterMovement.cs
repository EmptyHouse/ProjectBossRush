using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rigid
    {
        get
        {
            return characterStats.rigid;
        }
    }
    public CharacterStats characterStats;
    public float hInput { get; private set; }
    public float vInput { get; private set; }

    #region monobehaviour methods
    private void Awake()
    {
        characterStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {

    }
    #endregion monobehaviour methods
    private void UpdateMovementBasedOnInput()
    {
        
    }


    public void SetDirectionalInput(float horizontal, float vertical)
    {
        hInput = horizontal;
        vInput = vertical;
    }

}
