using System;
using System.Linq;
using Core.Bricks.Data;
using Core.Data;
using UnityEngine;

namespace Core.Bricks.Model
{
    public class BrickModel
    {
        public event Action UpdateBrick = delegate {  };

        public Vector2 Position { get; private set; }        
        public Vector2 Size { get; private set; }
        
        public int Row { get; private set; }
        
        public bool IsDead => BrickSettings.BrickType == BrickType.Null;

        private readonly BricksConfig _bricksConfig;
        public BrickSettings BrickSettings { get; private set; }
        
        public BrickModel(GameSettings gameSettings)
        {
            _bricksConfig = gameSettings.BricksConfig;
        }

        public void Initialize(Vector2 position, BrickType brickType, int row)
        {
            Position = position;
            Row = row;
            
            Size = _bricksConfig.BrickSize + _bricksConfig.BrickOffset;

            UpdateBrickType(brickType);
        }

        private void UpdateBrickType(BrickType brickType)
        {
            BrickSettings = _bricksConfig.BricksSettingses.FirstOrDefault(x => x.BrickType == brickType);
                        
            UpdateBrick?.Invoke();
        }
        
        public void Damage(int damage)
        {
            UpdateBrickType(BrickSettings.NextBrickType);
        }
    }
}
