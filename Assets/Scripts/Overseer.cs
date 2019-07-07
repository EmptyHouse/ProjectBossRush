using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overseer : MonoBehaviour
{
    #region static variables
    private static Overseer instance;

    public static Overseer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Overseer>();
            }
            return instance;
        }
    }
    #endregion static variables

    #region main variables
    public HitboxManager hitboxManager
    {
        get; set;
    }

    [SerializeField]
    public Transform ProjectileParentTransform;
    #endregion main variables

    #region monobeahviour methods
    private void Awake()
    {
        instance = this;
    }
    #endregion monobehavoiur methods

    #region Prefab References

    [SerializeField]
    private GameObject ProjectileObject;

    public GameObject Projectile
    {
        get
        {
            return ProjectileObject;
        }
    }

    #endregion

}
