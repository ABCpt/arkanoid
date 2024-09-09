using System;
using Core.Data;
using Core.Projectile.Data;
using UnityEngine;
using Utils;

namespace Core.Projectile.Model
{
    public class ProjectileModel
    {
        public event Action UpdatePosition = delegate {  };
        public Vector2 Position { get; private set; }   
        public Vector2 LastPosition { get; private set; }
        public float Radius { get; private set; }        
        public int Damage { get; private set; }
        public float Speed { get; private set; }

        
        private readonly ProjectileConfig _projectileConfig;

        public Vector2 MoveDirection { get; private set; }


        public ProjectileModel(GameSettings gameSettings)
        {
            _projectileConfig = gameSettings.ProjectileConfig;
            
            Initialize();
        }

        public void Initialize()
        {
            Radius = _projectileConfig.ProjectileRadius;
            Damage = _projectileConfig.ProjectileDamage;
            Speed = _projectileConfig.ProjectileSpeed;
        }
        
        public ProjectileModel SetPosition(Vector2 position)
        {
            Position = position;
            UpdatePosition?.Invoke();
            return this;
        }
        
        public ProjectileModel SetDirection(Vector2 direction)
        {
            MoveDirection = direction;
            return this;
        }

        public void Reflect(Vector2 normal)
        {
            var newDirection = GameHelper.GetReflection(MoveDirection, normal);
            
            MoveDirection = newDirection;
            ReturnPosition();
        }

        private void ReturnPosition()
        {
            Position = LastPosition;
            UpdatePosition?.Invoke();
        }

        public void Move()
        {
            LastPosition = Position;
            Position += MoveDirection * _projectileConfig.ProjectileSpeed * Time.deltaTime;
            UpdatePosition?.Invoke();
        }
        
        public void ForceMove(Vector2 direction)
        {
            Position += direction * _projectileConfig.ProjectileSpeed * Time.deltaTime * 2f;
            LastPosition = Position;
            UpdatePosition?.Invoke();
        }
    }
}
