using Core.Bricks.Data;
using Core.Level.Data;
using Core.Player.Data;
using Core.Projectile.Data;
using Core.Weapon.Data;
using UnityEngine;

namespace Core.Data
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Data/Settings/GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [field: SerializeField, Space] public PlayerConfig PlayerConfig { get; private set; }

        [field: SerializeField, Space] public BricksConfig BricksConfig { get; private set; }

        [field: SerializeField, Space] public LevelConfig LevelConfig { get; private set; }

        [field: SerializeField, Space] public WeaponConfig WeaponConfig { get; private set; }
        
        [field: SerializeField, Space] public ProjectileConfig ProjectileConfig { get; private set; }
    }
}
