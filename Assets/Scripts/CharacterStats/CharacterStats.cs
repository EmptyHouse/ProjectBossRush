using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A script that hold references to important behviaours and stats that an object may need to know to interact with a character
/// </summary>
public class CharacterStats : MonoBehaviour {
    public enum SpriteLayer : int
    {
        Environment = 0x01,
        Player = 0x03,

    }


    [Tooltip("The maximum health of this character")]
    public float maxHealth = 10;
    [Tooltip("The current health of this character")]
    private float currentHealth;
    public HitboxManager hitboxManager;
    /// <summary>
    /// Associated animator with our character.
    /// </summary>
    public Animator anim { get; private set; }
    public Rigidbody rigid { get; private set; }
    /// <summary>
    /// Associated character movement script. If there is none this value will be null
    /// </summary>
    public CharacterMovement characterMovement { get; set; }
    #region monobehaviour methods
    private void Awake()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        hitboxManager = GetComponent<HitboxManager>();
    }


    #endregion monobehaviour methods

    #region health methods
    /// <summary>
    /// Method that should be called whenever we heal our character
    /// </summary>
    /// <param name="healthToAdd"></param>
    public virtual void HealCharacter(float healthToAdd)
    {
        currentHealth += healthToAdd;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    /// <summary>
    /// Whenever this character takes damage, this method should be called
    /// </summary>
    /// <param name="damageToTake"></param>
    /// <returns></returns>
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
