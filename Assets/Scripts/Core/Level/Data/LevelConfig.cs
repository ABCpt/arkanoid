using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Level.Data
{
    [Serializable]
    public class LevelConfig
    {
        [Tooltip("Levels")]
        [field:SerializeField] public List<LevelData> Levels { get; private set; }
        
        [field:SerializeField] public int CameraSize { get; private set; }
        [field: SerializeField] public float FieldAspectRatio { get; private set; } = 1080f / 1920f;

        [field: SerializeField] public float BrickScore { get; private set; } = 100;
    }
}
