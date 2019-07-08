using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHandler : MonoBehaviour
{

    #region main variables

    public CharacterStats AssociatedCharacterStats { get; set; }

    public Animator Animator { get; private set; }

    public CharacterMovement CharacterMovement { get; private set; }
        

    #endregion

    #region monobehaviour methods

    void Update()
    {
        
    }

    private void Awake()
    {
        AssociatedCharacterStats = GetComponent<CharacterStats>();
        Animator = GetComponent<Animator>();
        CharacterMovement = GetComponent<CharacterMovement>();
    }

    #endregion

    #region public methods

    public void HandleFireButton()
    {
        CreateProjectile();
    }

    #endregion

    #region private methods

    private void CreateProjectile()
    {
            Projectile projectile = Instantiate(Overseer.Instance.Projectile, this.transform.position, Quaternion.identity, Overseer.Instance.ProjectileParentTransform).GetComponent<Projectile>();
            projectile.SetupProjectile(AssociatedCharacterStats, CharacterMovement.CharacterDirection);
    }

    #endregion
}
