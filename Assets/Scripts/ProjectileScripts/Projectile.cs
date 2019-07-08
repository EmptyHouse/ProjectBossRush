using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    #region const variables

    private const float DIRECTION_TO_DEGREES = 45f;

    private const float PROJECTILE_SPEED = 10f;

    #endregion

    #region main variables

    /// <summary>
    /// A reference to the character that fired this projectile
    /// </summary>
    public CharacterStats AssociatedCharacterStats { get; set; }

    /// <summary>
    /// Associated rigid body with our projectile
    /// </summary>
    public Rigidbody2D rigid { get; private set; }

    public Animator Animator { get; private set; }

    public SpriteRenderer SpriteRenderer;

    public InteractionHandler InteractionHandler { get; set; }

    /// <summary>
    /// Direction of the projectile. Usually shouldn't change once projectile is instantiated.
    /// Can maybe change if projectile arcs, but that's a different story.
    /// </summary>
    private Vector2 Direction;

    public float ProjectileLifetime;

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

    protected virtual void OnDestroy()
    {
        Debug.LogWarning("Projectile destroyed");
    }
    #endregion monobehaviour methods

    #region public methods

    public void SetupProjectile(CharacterStats associatedCharacterInfo, CharacterMovement.Direction direction)
    {
        AssociatedCharacterStats = associatedCharacterInfo;

        float component = (float)direction * DIRECTION_TO_DEGREES;
        Vector3 rotation = new Vector3(0f, 0f, component);
        this.transform.eulerAngles = rotation;

        float degrees = Mathf.Deg2Rad * component;
        Vector2 directionVector = new Vector2(Mathf.Cos(degrees), Mathf.Sin(degrees)) * PROJECTILE_SPEED;
        directionVector += AssociatedCharacterStats.characterMovement.rigid.velocity;

        rigid.velocity = directionVector;
        Direction = directionVector;

        StartCoroutine(DestroyProjectileAfterLifetime());
    }

    #endregion

    #region private methods

    private IEnumerator DestroyProjectileAfterLifetime()
    {
        float lifetime = ProjectileLifetime;
        while (lifetime > 0.0f)
        {
            yield return new WaitForEndOfFrame();
            lifetime -= Time.deltaTime;
        }
        GameObject.Destroy(this.gameObject);
    }

    #endregion

}
