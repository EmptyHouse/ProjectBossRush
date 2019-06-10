using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    #region main variables
    public float maxHealth { get; private set; }
    public float currentHealth { get; private set; }

    public Rigidbody2D rigid { get; set; }
    public CharacterMovement characterMovement {get; set;}
    
    #endregion main variables
    #region monobehaviour methods
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }


    #endregion monobehaviuor methods

    #region health methods
    public void AddHealthToCharacter(float healthToAdd)
    {
        currentHealth += healthToAdd;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    public void TakeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnCharacterIsDead();
        }
    }

    private void OnCharacterIsDead()
    {
        Destroy(this.gameObject);
    }
    #endregion health methods
}
