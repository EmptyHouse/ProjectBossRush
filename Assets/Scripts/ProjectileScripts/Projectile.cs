using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    #region main variables

    private const float Offset = 10f;

    /// <summary>
    /// A reference to the character that fired this projectile
    /// </summary>
    public CharacterStats AssociatedCharacterStats { get; set; }

    /// <summary>
    /// Associated rigid body with our projectile
    /// </summary>
    private Rigidbody2D rigid;

    private Animator Animator { get; set; }

    /// <summary>
    /// Direction of the projectile. Usually shouldn't change once projectile is instantiated.
    /// Can maybe change if projectile arcs, but that's a different story.
    /// </summary>
    private Vector2 Direction;

    #endregion


    #region monobehaviour methods
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        
    }
    #endregion monobehaviour methods

    #region public methods

    public void SetupProjectile(Vector2 Direction, CharacterStats associatedCharacterInfo)
    {
        AssociatedCharacterStats = associatedCharacterInfo;
    }

    #endregion

}
