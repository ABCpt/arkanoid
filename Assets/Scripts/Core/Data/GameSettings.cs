using Core.Bricks.Data;
using Core.Level.Data;
using Core.Platform.Data;
using Core.Projectile.Data;
using Core.Weapon.Data;
using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Data/Settings/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField, Space] public PlatformConfig PlatformConfig { get; private set; }

        [field: SerializeField, Space] public BricksConfig BricksConfig { get; private set; }

        [field: SerializeField, Space] public LevelConfig LevelConfig { get; private set; }

        [field: SerializeField, Space] public WeaponConfig WeaponConfig { get; private set; }
        
        [field: SerializeField, Space] public ProjectileConfig ProjectileConfig { get; private set; }
    }
}
