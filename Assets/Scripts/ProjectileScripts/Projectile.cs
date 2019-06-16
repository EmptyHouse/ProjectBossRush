using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    /// <summary>
    /// A reference to the character that fired this projectile
    /// </summary>
    public CharacterStats associatedCharacterStats { get; set; }
    /// <summary>
    /// Associated rigid body with our projectile
    /// </summary>
    private Rigidbody2D rigid;


    #region monobehaviour methods
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        
    }
    #endregion monobehaviour methods

}
