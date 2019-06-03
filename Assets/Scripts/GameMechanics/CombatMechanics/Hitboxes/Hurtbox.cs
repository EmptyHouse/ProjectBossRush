using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Hurtbox : MonoBehaviour
{
    private CharacterStats associatedCharacterStats;
    
    #region monobehaviour methods
    private void Awake()
    {
        associatedCharacterStats = GetComponentInParent<CharacterStats>();
        if (associatedCharacterStats == null)
        {
            Debug.LogWarning("There were no character stats found associated with this hurtbox");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Hitbox hitbox = other.GetComponent<Hitbox>();
        if (hitbox)
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        Hitbox hitbox = other.GetComponent<Hitbox>();
        if (hitbox)
        {

        }
    }
    #endregion monobehaviour methods

}
