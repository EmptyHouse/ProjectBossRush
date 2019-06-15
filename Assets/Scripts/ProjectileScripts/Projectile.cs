using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /// <summary>
    /// A reference to the character that fired this projectile
    /// </summary>
    public CharacterStats associatedCharacterStats { get; set; }

}
