using System;
using Core.Projectile.View;
using UnityEngine;

namespace Core.Projectile.Data
{
    [Serializable]
    public class ProjectileConfig
    {
        [field: SerializeField] public ProjectileView ProjectilePrefab;

        [Tooltip("Speed of a player projectile")]
        [field: SerializeField, Range(0, 50)] public float ProjectileSpeed { get; private set; } = 10f;

        [Tooltip("Shot damage")]
        [field:SerializeField, Range(0, 3)] public int ProjectileDamage { get; private set; } = 1;
        
        [Tooltip("Projectile Radius")]
        [field:SerializeField] public float ProjectileRadius { get; private set; } = 0.1f;
    }
}
