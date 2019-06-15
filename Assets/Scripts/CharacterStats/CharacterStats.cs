using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float maxHealth = 100;

    private float currentHealth;
    public Rigidbody2D rigid { get; private set; }

    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

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
