using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Base class of our custom collider. This will check to see if there are any points where our collider intersects
/// with other colliders.
/// </summary>
public abstract class CustomCollider2D : MonoBehaviour
{
    [Tooltip("Mark this value true if you would like to treat this value as a trigger")]
    public bool isTrigger;

    public bool isStatic;
    /// <summary>
    /// 
    /// </summary>
    public ColliderBounds bounds { get; set; }
    /// <summary>
    /// 
    /// </summary>
    protected ColliderBounds previouBounds { get; set; }

    /// <summary>
    /// Be sure to call this methodd
    /// </summary>
    protected virtual void UpdateBoundsOfCollider()
    {
        previouBounds = bounds;
    }


    /// <summary>
    /// Call this method to check if we intersect with a colider
    /// </summary>
    /// <param name="colliderToCheck"></param>
    /// <returns></returns>
    public virtual bool IntersectWithCollider(CustomCollider2D colliderToCheck)
    {
        return false;
    }

    public struct ColliderBounds
    {
        public Vector2 topLeft;
        public Vector2 topRight;
        public Vector2 bottomLeft;
        public Vector2 bottomRight;

        public Vector3[] GetVertices()
        {
            return new Vector3[]
            {
                topLeft,
                topRight,
                bottomRight,
                bottomLeft,
            };
        }
    }
}
