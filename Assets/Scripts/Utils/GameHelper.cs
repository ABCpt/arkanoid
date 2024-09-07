using System.Collections.Generic;
using System.Linq;
using Core.Projectile.Model;
using UnityEngine;

namespace Utils
{
    public static class GameHelper
    {
        private const int AngleProjectilePoint = 10;
        private static Dictionary<int, Vector2> ProjectilePoints = new Dictionary<int, Vector2>();

        public static Rect GetRectByPositionAndSize(Vector2 position, Vector2 size)
        {
            return new Rect(position - size / 2f, size);
        }
        
        public static bool IsProjectileWithRectCollision(ProjectileModel projectileModel, Rect rect)
        {
            if (rect.Contains(projectileModel.Position))
                return true;
            
            var collisionPoints = GetProjectilePoints(projectileModel);
            foreach (var point in collisionPoints)
            {
                if (rect.Contains(point))
                    return true;
            }
            
            return false;
        }

        private static Vector2[] GetProjectilePoints(ProjectileModel projectileModel)
        {
            var center = projectileModel.Position;

            if (ProjectilePoints == null || ProjectilePoints.Count == 0)
                CreateProjectilePoints(projectileModel.Radius);

            return ProjectilePoints.Values.Select(x => x + center).ToArray();
        }

        private static void CreateProjectilePoints(float radius)
        {
            for (int i = 0; i < 360 / AngleProjectilePoint; i++)
            {
                var angle = i * AngleProjectilePoint;
                var x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
                var y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
                var offsetPosition = new Vector2(x, y);
                ProjectilePoints.Add(angle, offsetPosition);
            }
        }
        
        public static Vector2 GetCollisionNormal(ProjectileModel projectileModel, Rect rect)
        {
            var maxDistance = 1f;
            var normal = Vector2.one;

            if (Mathf.Abs(projectileModel.Position.x + projectileModel.Radius - rect.xMin) < maxDistance)
            {
                maxDistance = Mathf.Abs(projectileModel.Position.x - projectileModel.Radius - rect.xMin);
                normal = Vector2.left;
            }
            if (Mathf.Abs(projectileModel.Position.x - projectileModel.Radius - rect.xMax) < maxDistance)
            {
                maxDistance = Mathf.Abs(projectileModel.Position.x + projectileModel.Radius - rect.xMax);
                normal = Vector2.right;
            }
            if (Mathf.Abs(projectileModel.Position.y + projectileModel.Radius - rect.yMin) < maxDistance)
            {
                maxDistance = Mathf.Abs(projectileModel.Position.y - projectileModel.Radius - rect.yMin);
                normal = Vector2.up;
            }
            if (Mathf.Abs(projectileModel.Position.y - projectileModel.Radius - rect.yMax) < maxDistance)
            {
                maxDistance = Mathf.Abs(projectileModel.Position.y + projectileModel.Radius - rect.yMax);
                normal = Vector2.down;
            }

            return normal;
        }
    }
}
