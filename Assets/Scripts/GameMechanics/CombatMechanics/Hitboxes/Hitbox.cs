using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider))]
public class Hitbox : MonoBehaviour
{
    private CharacterStats associatedCharacterStats;
    #region hitbox event variables
    private UnityEvent OnHitboxEnteredEvent;
    private UnityEvent OnHitboxExitEvent;
    
    private UnityEvent OnHurtboxEnteredEvent;
    private UnityEvent OnHurtboxExitEvent;

    private UnityEvent OnOtherColliderEnter;
    private UnityEvent OnOtherColliderExit;
    #endregion hitbox event variables

    #region monobehaviour methods
    private void Awake()
    {
        associatedCharacterStats = GetComponentInParent<CharacterStats>();
        if (!associatedCharacterStats)
        {
            Debug.LogWarning("There were no character stats for this hitbox");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Hurtbox hurtbox = other.GetComponent<Hurtbox>();
        Hitbox hitbox = other.GetComponent<Hitbox>();
        if (hurtbox)
        {

        }
        if (hitbox)
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        Hurtbox hurtbox = other.GetComponent<Hurtbox>();
        Hitbox hitbox = other.GetComponent<Hitbox>();

        if (hurtbox)
        {

        }
        if (hitbox)
        {

        }
    }
    #endregion monobehaviour methods
}
