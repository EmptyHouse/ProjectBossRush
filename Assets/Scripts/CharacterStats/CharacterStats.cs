using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public enum CharacterTeam
    {
        ENEMIES,
        ALLIES,
    }

    public CharacterTeam characterTeam = CharacterTeam.ENEMIES;

    public float maxHealth = 100;

    private float currentHealth;
    public Rigidbody2D rigid { get; private set; }
    public Animator anim { get; private set; }
    public CharacterMovement characterMovement { get; private set; }
    public CombatHandler CombatHandler { get; private set; }


    #region monobehaviour methods
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();


        characterMovement = GetComponent<CharacterMovement>();
        characterMovement.associatedCharacterStats = this;

        CombatHandler = GetComponent<CombatHandler>();
        CombatHandler.AssociatedCharacterStats = this;

    }
    #endregion monobehaviour methods

    #region health related methods
    public void AddHealthToCharacter(float healthToAdd)
    {
        currentHealth += healthToAdd;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    public void DamageTakenToCharacter(float damageToTake)
    {
        currentHealth -= damageToTake;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnCharacterDead();
        }
    }

    /// <summary>
    /// This method will be called whenever a character has reached a health of 0 or less
    /// </summary>
    public virtual void OnCharacterDead()
    {
        Destroy(this.gameObject);
    }
    #endregion health related methods
}
