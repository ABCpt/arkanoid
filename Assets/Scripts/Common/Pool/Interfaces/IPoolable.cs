using UnityEngine;

namespace Common.Pool.Interfaces
{
    public interface IPoolable
    {
        void OnSpawn(Transform parent);
        void OnDespawn(Transform parent);
    }
}