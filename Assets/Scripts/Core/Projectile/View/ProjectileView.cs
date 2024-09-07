using System;
using Common.Pool.View;
using Core.Projectile.Model;
using UnityEngine;

namespace Core.Projectile.View
{
    public class ProjectileView : BasePoolable
    {
        public ProjectileModel Model { get; private set; }

        public void Initialize(ProjectileModel model)
        {
            Model = model;

            Model.UpdatePosition += OnUpdatePosition;
            
            OnUpdatePosition();
        }

        private void OnUpdatePosition()
        {
            transform.position = Model.Position;
        }
    }
}

