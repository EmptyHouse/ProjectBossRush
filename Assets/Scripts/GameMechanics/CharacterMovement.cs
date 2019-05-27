using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStats))]
public class CharacterMovement : MonoBehaviour
{
    #region main variables
    public float walkingSpeed = 5;
    public float runningSpeed = 10;

    /// <summary>
    /// This Character's associated stats
    /// </summary>
    public CharacterStats associatedCharacterStats { get; private set; }
    private Vector2 characterMovementInput;
    #endregion main variables

    #region monobehaviour methods
    private void Awake()
    {
        this.associatedCharacterStats = GetComponent<CharacterStats>();
        associatedCharacterStats.characterMovement = this;
    }


    private void Update()
    {
        
    }
    #endregion monobehaviour methods

    public void UpdateVelocityForMovementFromInput()
    {

    }

    /// <summary>
    /// Assign the input for our character's movement. This will be used to assign the speed and direction
    /// they will move
    /// </summary>
    /// <param name="horizontal"></param>
    /// <param name="vertical"></param>
    public void SetMovementInput(float horizontal, float vertical)
    {
        characterMovementInput.x = horizontal;
        characterMovementInput.y = vertical;
    }


}
