using System;
using UnityEngine;

namespace Core.Player.Data
{
    [Serializable]
    public class PlayerConfig
    {
        [Tooltip("Health of player")]
        [field:SerializeField] public int Health { get; private set; } = 3;

        [Tooltip("Player speed")]
        [field:SerializeField, Range(0, 15)] public float Speed { get; private set; } = 3f;
        
        [Tooltip("Position of the player at start")]
        [field:SerializeField] public Vector3 StartPosition { get; private set; } = new(0f, -9f, 0f);
        
        [Tooltip("Player size")]
        [field:SerializeField] public Vector2 PlayerSize { get; private set; } = Vector2.one;
    }
}
