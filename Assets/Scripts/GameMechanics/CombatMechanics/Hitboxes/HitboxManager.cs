using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HitboxManager : MonoBehaviour
{
    #region hitbox events
    private UnityEvent OnHitboxEnteredHitboxEvent;
    private UnityEvent OnHitboxExitHitboxEvent;

    private UnityEvent OnHitboxEnteredHurtboxEvent;
    private UnityEvent OnHitboxExitHurtboxEvent;

    private UnityEvent OnHitboxEnterOtherColliderEvent;
    private UnityEvent OnHitboxExitOtherColliderEvent;
    #endregion hitbox events;


    #region hurtbox events

    #endregion hurtbox events

    #region main variables
    private List<CharacterStats> listOfCharacterStatsThatHaveBeenHit = new List<CharacterStats>();
    #endregion main variables

    private void Awake()
    {
        
    }


    public void ResetAttack()
    {

    }
    #region hitbox event methods
    /// <summary>
    /// 
    /// </summary>
    public void OnHitboxEnteredHitbox()
    {
        OnHitboxEnteredHitboxEvent.Invoke();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnHitboxExitHitbox()
    {
        OnHitboxExitHitboxEvent.Invoke();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnHitboxEnteredHurtbox()
    {
        OnHitboxEnteredHurtboxEvent.Invoke();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnHitboxExitHurtbox()
    {
        OnHitboxExitHurtboxEvent.Invoke();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnHitboxEnterOtherCollier()
    {
        OnHitboxEnterOtherColliderEvent.Invoke();
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void OnHitboxExitOtherCollider()
    {
        OnHitboxExitOtherColliderEvent.Invoke();
    }
    #endregion hitbox event methods

    #region hurtbox event methods
    
    #endregion hurtbox event methods
}
