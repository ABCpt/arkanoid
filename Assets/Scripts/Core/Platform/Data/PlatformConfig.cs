using System;
using UnityEngine;

namespace Core.Platform.Data
{
    [Serializable]
    public class PlatformConfig
    {
        [Tooltip("Health of platform")]
        [field:SerializeField] public int Health { get; private set; } = 3;

        [Tooltip("Platform speed")]
        [field:SerializeField, Range(0, 15)] public float Speed { get; private set; } = 3f;
        
        [Tooltip("Position of the platform at start")]
        [field:SerializeField] public Vector3 StartPosition { get; private set; } = new(0f, -9f, 0f);
        
        [Tooltip("Platform size")]
        [field:SerializeField] public Vector2 PlatformSize { get; private set; } = Vector2.one;
    }
}
