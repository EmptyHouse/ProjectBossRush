using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script that hold references to important behviaours and stats that an object may need to know to interact with a character
/// </summary>
public class CharacterStats : MonoBehaviour {
    [Tooltip("The maximum health of this character")]
    public float maxHealth = 10;
    [Tooltip("The current health of this character")]
    private float currentHealth;
    [Tooltip("The associated animator")]
    public Animator anim;
    public CharacterMovement characterMovement;
    #region monobehaviour methods
    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
    }


    #endregion monobehaviour methods

    #region health methods
    public virtual float TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnCharacterDied();
        }
        return currentHealth;
    }

    /// <summary>
    /// When our character has reached below or at 0 health, we will call this method
    /// 
    /// </summary>
    public virtual void OnCharacterDied()
    {
        Destroy(this.gameObject);
    }
    #endregion health methods
}
