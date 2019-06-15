using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float maxRunSpeed;
    public float maxWalkSpeed;
    public float acceleration;
    private CharacterStats associatedCharacterStats;


    private float xInput;
    private float yInput;
    #region monobehavoiur methods
    private void Awake()
    {
        associatedCharacterStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        
    }
    #endregion monobehaviour methods

    private void UpdateMovementBasedOnDirectionalInput()
    {

    }

    private void SetDirectionalInput(float xInput, float yInput)
    {

    }
}
