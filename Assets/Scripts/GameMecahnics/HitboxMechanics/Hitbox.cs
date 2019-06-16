using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public abstract class Hitbox : MonoBehaviour
{
    private UnityEvent<Collider2D> OnHitboxEnterColliderEvent;
    private UnityEvent<Collider2D> OnHitboxExitColliderEvent;
    private UnityEvent<Hurtbox> OnHitboxEnterHurtboxEvent;
    private UnityEvent<Hurtbox> OnHitboxExitHurtboxEvent;

    public void AddActionToHitboxEnterHurtboxEvent()
    {

    }

}
