using System;
using Core.Data;
using Core.Level.Data;
using Core.Level.Interface;
using Core.Player.Data;
using UnityEngine;

namespace Core.Player.Model
{
    public class PlayerModel : ILevelStartable
    {
        public event Action UpdatePosition = delegate {  };
        public event Action UpdateHealth = delegate {  };
        public Vector2 Position { get; private set; }
        public Vector2 Size { get; private set; }
        
        public int Health { get; private set; }
        public bool IsDead => Health <= 0;
        public Vector2 LastDirection { get; private set; }
        
        private readonly PlayerConfig _playerConfig;
        private readonly LevelConfig _levelConfig;

        public PlayerModel(GameSettings gameSettings)
        {
            _playerConfig = gameSettings.PlayerConfig;
            _levelConfig = gameSettings.LevelConfig;

            Size = _playerConfig.PlayerSize;
        }

        public void Move(Vector2 direction)
        {
            direction *= Vector2.right;
            LastDirection = direction.normalized;
            
            var position = Position + direction * _playerConfig.Speed * Time.deltaTime;
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
                -_levelConfig.CameraSize * _levelConfig.FieldAspectRatio + _playerConfig.PlayerSize.x / 2, 
                _levelConfig.CameraSize * _levelConfig.FieldAspectRatio - _playerConfig.PlayerSize.x / 2);

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
            Position = _playerConfig.StartPosition;
            Health = _playerConfig.Health;
            
            UpdatePosition?.Invoke();
            UpdateHealth?.Invoke();
        }
        
        public bool IsCollision(Vector2 position)
        {
            var xOffset = _playerConfig.PlayerSize.x / 2f;
            var yOffset = _playerConfig.PlayerSize.y / 2f;

            return position.x > Position.x - xOffset && position.x < Position.x + xOffset &&
                   position.y > Position.y - yOffset && position.y < Position.y + yOffset;
        }
    }
}
