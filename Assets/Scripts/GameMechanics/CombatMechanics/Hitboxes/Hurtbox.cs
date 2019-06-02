using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hurtbox : MonoBehaviour
{
    private CharacterStats associatedCharacterStats;
    private UnityEvent OnHurtboxEnteredEvent;
    private UnityEvent OnHurtboxExitEvent;

    #region monobehaviour methods
    private void Awake()
    {
        associatedCharacterStats = GetComponentInParent<CharacterStats>();
        if (associatedCharacterStats == null)
        {
            Debug.LogWarning("There were no character stats found associated with this hurtbox");
        }
    }
    #endregion monobehaviour methods

    /// <summary>
    /// Add an action event to occur whenever a hurtbox has enetered our hurtbox
    /// </summary>
    /// <param name="actionEvent"></param>
    public void AddFunctionToHurtboxEnteredEvent(UnityAction actionEvent)
    {
        OnHurtboxEnteredEvent.AddListener(actionEvent);
    }

    /// <summary>
    /// Add an action event to occur whenever a hitbox has exited our hurtbox
    /// </summary>
    /// <param name="actionEvent"></param>
    public void AddFunctionToHurtboxExitEvent(UnityAction actionEvent)
    {
        OnHurtboxExitEvent.AddListener(actionEvent);
    }

}
