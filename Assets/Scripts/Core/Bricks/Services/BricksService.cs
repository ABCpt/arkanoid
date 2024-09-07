using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Bricks.Data;
using Core.Bricks.Model;
using Core.Data;
using Core.Level.Data;
using Core.Level.Interface;
using Core.Level.Model;
using Core.Projectile.Model;
using UnityEngine;
using Utils;

namespace Core.Bricks.Services
{
    public class BricksService : ILevelFinishable
    {
        private readonly BricksFactory _bricksFactory;
        private readonly List<Vector2> _spawnPoints = new List<Vector2>();
        private readonly LevelModel _levelModel;
        private readonly BricksConfig _bricksConfig;

        public List<BrickModel> BrickModels { get; private set; }  = new List<BrickModel>();

        public BricksService(BricksFactory bricksFactory, LevelModel levelModel, GameSettings gameSettings)
        {
            _bricksFactory = bricksFactory;
            _levelModel = levelModel;
            _bricksConfig = gameSettings.BricksConfig;
        }

        public void SpawnBrick(Vector2 position, BrickType brickType, int row)
        {
            var model = _bricksFactory.Spawn(position, brickType, row);
            BrickModels.Add(model);
        }

        private void DespawnBrick(BrickModel model)
        {
            if (BrickModels.Contains(model))
                BrickModels.Remove(model);
            
            _bricksFactory.Despawn(model);
            _levelModel.DestroyBrick();
        }

        public void DamageBrick(BrickModel model, int damage)
        {
            model.Damage(damage);
            
            if(model.IsDead)
                DespawnBrick(model);
        }

        public void AddSpawnPoint(Vector2 spawnPoint)
        {
            if (!_spawnPoints.Contains(spawnPoint))
                _spawnPoints.Add(spawnPoint);
        }

        public async void FinishLevel()
        {
            await Task.Yield();
            
            foreach (var brickModel in BrickModels)
            {
                _bricksFactory.Despawn(brickModel);
            }
            BrickModels?.Clear();
        }

        public BrickModel GetBrickCollisionWithProjectile(ProjectileModel projectileModel)
        {
            foreach (var brickModel in BrickModels)
            {
                var rect = GameHelper.GetRectByPositionAndSize(brickModel.Position, brickModel.Size);

                if (GameHelper.IsProjectileWithRectCollision(projectileModel, rect))
                    return brickModel;
            }

            return null;
        }
    }
}
