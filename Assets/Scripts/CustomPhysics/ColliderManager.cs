using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// </summary>
public class ColliderManager : MonoBehaviour
{
    private List<CustomCollider2D> colliderList = new List<CustomCollider2D>();

    #region monobehaviour methods
    private void Awake()
    {
        Overseer.Instance.colliderManager = this;
    }

    private void Update()
    {
        
    }
    #endregion monobehaviour methods

    #region collider interaction methods


    public void AddColliderToManager(CustomCollider2D collider)
    {
        if (colliderList.Contains(collider))
        {
            return;
        }
        colliderList.Add(collider);
    }

    public void RemoveColliderFromManager(CustomCollider2D collider)
    {
        if (!colliderList.Contains(collider))
        {
            return;
        }
        colliderList.Remove(collider);
    }
    #endregion collider interaction methods
}
