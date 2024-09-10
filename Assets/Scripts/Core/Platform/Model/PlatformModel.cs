using System;
using Core.Data;
using Core.Level.Data;
using Core.Level.Interface;
using Core.Platform.Data;
using UnityEngine;

namespace Core.Platform.Model
{
    public class PlatformModel : ILevelStartable
    {
        public event Action UpdatePosition = delegate {  };
        public event Action UpdateHealth = delegate {  };
        public Vector2 Position { get; private set; }
        public Vector2 Size { get; private set; }
        
        public int Health { get; private set; }
        public bool IsDead => Health <= 0;
        public Vector2 LastDirection { get; private set; }
        
        private readonly PlatformConfig _platformConfig;
        private readonly LevelConfig _levelConfig;

        public PlatformModel(GameSettings gameSettings)
        {
            _platformConfig = gameSettings.PlatformConfig;
            _levelConfig = gameSettings.LevelConfig;

            Size = _platformConfig.PlatformSize;
        }

        public void Move(Vector2 direction)
        {
            direction *= Vector2.right;
            LastDirection = direction.normalized;
            
            var position = Position + direction * _platformConfig.Speed * Time.deltaTime;
            Position = ClampPosition(position);
            
            UpdatePosition?.Invoke();
        }

        public void StopMove()
        {
            LastDirection = Vector2.zero;
        }

        private Vector2 ClampPosition(Vector2 position)
        {
            var correctPosition = Vector2.zero;
            
            correctPosition.x = Mathf.Clamp(position.x, 
                -_levelConfig.CameraSize * _levelConfig.FieldAspectRatio + _platformConfig.PlatformSize.x / 2, 
                _levelConfig.CameraSize * _levelConfig.FieldAspectRatio - _platformConfig.PlatformSize.x / 2);

            correctPosition.y = position.y; 
            
            return correctPosition;
        }
        
        public void Damage(int damage)
        {
            Health -= damage;

            Health = Health < 0 ? 0 : Health;
            
            UpdateHealth?.Invoke();
        }

        public void StartLevel()
        {
            Position = _platformConfig.StartPosition;
            Health = _platformConfig.Health;
            
            UpdatePosition?.Invoke();
            UpdateHealth?.Invoke();
        }

        public void Collision()
        {
            Move(LastDirection);
        }
    }
}
