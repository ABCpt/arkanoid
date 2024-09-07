using Common.Pool.Interfaces;
using UnityEngine;

namespace Common.Pool.View
{
    public class BasePoolable : MonoBehaviour, IPoolable
    {
        public virtual void OnSpawn(Transform parent)
        {
            if (parent != null)
                transform.SetParent(parent, false);

            gameObject.SetActive(true);
        }

        public virtual void OnDespawn(Transform parent)
        {
            if (parent != null)
                transform.SetParent(parent, false);
            
            gameObject.SetActive(false);
        }
    }
}