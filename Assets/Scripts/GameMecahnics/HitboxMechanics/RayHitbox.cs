using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extension of hitbox that uses raycasts to determine when we have collided with something
/// </summary>
public class RayHitbox : Hitbox
{
    [Tooltip("The total number of rays that we will shoot out. This can be useful if our projectile is particularly wide.")]
    public int rayCount = 2;
    [Tooltip("The spread")]
    public float rangeOfRays = 1;

    #region monobehaviour methods

    private void OnValidate()
    {
        if (rayCount < 2)
        {
            rayCount = 2;
        }
        if (rangeOfRays < 0)
        {
            rangeOfRays = 0;
        }
    }
    #endregion monobehaivour methods


}
