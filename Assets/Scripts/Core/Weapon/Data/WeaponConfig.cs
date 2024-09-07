using System;
using UnityEngine;

namespace Core.Weapon.Data
{
    [Serializable]
    public class WeaponConfig
    {
        [Tooltip("Weapon offset")]
        [field:SerializeField] public Vector2 WeaponOffset { get; private set; }
    }
}
