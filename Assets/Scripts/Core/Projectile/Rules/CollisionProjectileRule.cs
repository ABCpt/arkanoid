using Core.Data;
using Core.Bricks.Services;
using Core.Level.Data;
using Core.Level.Interface;
using Core.Platform.Model;
using Core.Projectile.Model;
using Core.Projectile.Services;
using UnityEngine;
using Utils;

namespace Core.Projectile.Rules
{
    public class CollisionProjectileRule : ILevelUpdatable
    {
        private readonly ProjectileService _projectileService;
        private readonly BricksService _bricksService;
        private readonly PlatformModel _platformModel;
        private readonly LevelConfig _levelConfig;

        private const float WallThickness = 10f;

        public CollisionProjectileRule(ProjectileService projectileService, GameSettings gameSettings, 
            BricksService bricksService, PlatformModel platformModel)
        {
            _projectileService = projectileService;
            _bricksService = bricksService;
            _platformModel = platformModel;
            _levelConfig = gameSettings.LevelConfig;
        }
        
        public void UpdateLevel()
        {
            foreach (var projectileModel in _projectileService.ProjectileModels)
            {
                if(BrickCollision(projectileModel))
                    continue;
                
                if (PlayerCollision(projectileModel))
                    continue;

                WallCollision(projectileModel);
            }
        }

        private bool BrickCollision(ProjectileModel projectileModel)
        {
            var brickModel = _bricksService.GetBrickCollisionWithProjectile(projectileModel);

            var isCollision = brickModel != null;

            if (isCollision)
            {
                _bricksService.DamageBrick(brickModel, projectileModel.Damage);
                
                var rect = GameHelper.GetRectByPositionAndSize(brickModel.Position, brickModel.Size);

                var normal = GameHelper.GetCollisionNormal(projectileModel, rect);

                _projectileService.ReflectProjectile(projectileModel, normal);
            }

            return isCollision;
        }
        
        private bool PlayerCollision(ProjectileModel projectileModel)
        {
            var rect = GameHelper.GetRectByPositionAndSize(_platformModel.Position, _platformModel.Size);
            
            var isCollision =  GameHelper.IsProjectileWithRectCollision(projectileModel, rect);

            if (isCollision)
            {
                var normal = GameHelper.GetCollisionNormal(projectileModel, rect);

                var isNormalUp = Vector2.Distance(normal, Vector2.up) < 0.01f;
                
                normal += normal + (isNormalUp ? _platformModel.LastDirection / 2f : Vector2.zero);

                if(isNormalUp)
                    _projectileService.ReflectProjectile(projectileModel, normal);
                else
                    projectileModel.ForceMove(normal);

                _platformModel.Collision();
            }

            return isCollision;
        }
        
        private bool WallCollision(ProjectileModel projectileModel)
        {
            var upWall = GameHelper.GetRectByPositionAndSize(new Vector2(0, _levelConfig.CameraSize + WallThickness / 2f), new Vector2(100, WallThickness));
            var isUpWallCollision = GameHelper.IsProjectileWithRectCollision(projectileModel, upWall);

            if (isUpWallCollision)
            {
                var normal = GameHelper.GetCollisionNormal(projectileModel, upWall);
                _projectileService.ReflectProjectile(projectileModel, normal);
                return true;
            }
            
            var leftWall= GameHelper.GetRectByPositionAndSize(new Vector2(-_levelConfig.CameraSize * _levelConfig.FieldAspectRatio - WallThickness / 2f, 0), new Vector2(WallThickness, 100));
            var isLeftWallCollision = GameHelper.IsProjectileWithRectCollision(projectileModel, leftWall);

            if (isLeftWallCollision)
            {
                var normal = GameHelper.GetCollisionNormal(projectileModel, leftWall);
                _projectileService.ReflectProjectile(projectileModel, normal);
                return true;
            }

            var rightWall = GameHelper.GetRectByPositionAndSize(new Vector2(_levelConfig.CameraSize * _levelConfig.FieldAspectRatio + WallThickness / 2f, 0), new Vector2(WallThickness, 100));
            var isRightWallCollision = GameHelper.IsProjectileWithRectCollision(projectileModel, rightWall);

            if (isRightWallCollision)
            {
                var normal = GameHelper.GetCollisionNormal(projectileModel, rightWall);
                _projectileService.ReflectProjectile(projectileModel, normal);
                return true;
            }

            return false;
        }
    }
}
