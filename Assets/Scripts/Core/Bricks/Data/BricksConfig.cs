using System;
using System.Collections.Generic;
using Core.Bricks.View;
using UnityEngine;

namespace Core.Bricks.Data
{
    [Serializable]
    public class BricksConfig
    {
        [field:SerializeField] public BrickView BrickPrefab { get; private set; }

        [field:SerializeField] public Vector2 BrickSize { get; private set; }
        [field:SerializeField] public Vector2 BrickOffset { get; private set; }
        
        [field:SerializeField] public List<BrickSettings> BricksSettingses { get; private set; }
        
        [field:SerializeField] public Color[] RowsColor { get; private set; }
        
    }
}
