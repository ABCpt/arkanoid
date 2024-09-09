using Core.Projectile.Model;
using UnityEngine;

namespace Utils
{
    public static class GameHelper
    {
        public static Rect GetRectByPositionAndSize(Vector2 position, Vector2 size)
        {
            return new Rect(position - size / 2f, size);
        }
        
        public static bool IsProjectileWithRectCollision(ProjectileModel projectileModel, Rect rect)
        {
            var closestPoint = new Vector2(
                Mathf.Clamp(projectileModel.Position.x, rect.xMin, rect.xMax),
                Mathf.Clamp(projectileModel.Position.y, rect.yMin, rect.yMax)
            );
            
            var distance = Vector2.Distance(projectileModel.Position, closestPoint);
            return distance < projectileModel.Radius;
        }
        
        public static Vector2 GetReflection(Vector2 direction, Vector2 normal)
        {
            return direction - 2 * Vector2.Dot(direction, normal) * normal;
        }

        public static Vector2 GetCollisionNormal(ProjectileModel projectileModel, Rect rect)
        {
            var closestPoint = new Vector2(
                Mathf.Clamp(projectileModel.LastPosition.x, rect.xMin, rect.xMax),
                Mathf.Clamp(projectileModel.LastPosition.y, rect.yMin, rect.yMax)
            );
            
            var normal = (projectileModel.Position - closestPoint).normalized;
            
            if (projectileModel.LastPosition.x < rect.xMin || projectileModel.LastPosition.x > rect.xMax)
                normal = Vector2.right * Mathf.Sign(projectileModel.LastPosition.x - rect.center.x);
            else if (projectileModel.LastPosition.y < rect.yMin || projectileModel.LastPosition.y > rect.yMax)
                normal = Vector2.up * Mathf.Sign(projectileModel.LastPosition.y - rect.center.y);

            return normal;
        }
    }
}
