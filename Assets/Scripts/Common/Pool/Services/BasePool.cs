using System;
using System.Collections.Generic;
using Common.Pool.View;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;
using Object = UnityEngine.Object;

namespace Common.Pool.Services
{
    public abstract class BasePool<T> where T : BasePoolable
    {
        private readonly Transform _poolStorage;
        private readonly DiContainer _diContainer;
        
        private const bool CollectionChecks = true;
        protected abstract int MaxPoolSize { get; }
    
        private const int DefaultCampacity = 10;

        private readonly Dictionary<string, object> _pools = new();

        protected BasePool(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _poolStorage = new GameObject(GetType().FullName).transform;
            Object.DontDestroyOnLoad(_poolStorage);
        }

        public T Spawn(string id)
        {
            var pool = GetPool(id);
            return pool.Get();
        }

        public void Despawn(T item, string id)
        {
            var pool = GetPool(id);
            pool.Release(item);
        }
        
        private ObjectPool<T> GetPool(string id)
        {
            if (_pools.TryGetValue(id, out var pool))
                return pool as ObjectPool<T>;

            var newPool = new ObjectPool<T>(
                                CreatePooledItem, 
                                OnTakeFromPool, 
                                OnReturnedToPool, 
                                OnDestroyPoolObject, 
                                CollectionChecks, DefaultCampacity, MaxPoolSize);
            
            _pools.Add(id, newPool);

            return newPool;
        }

        protected abstract GameObject GetPrefab();

        private T CreatePooledItem()
        {
            var prefab = GetPrefab();
            var item = _diContainer.InstantiatePrefabForComponent<T>(prefab);

            return item;
        }

        private void OnReturnedToPool(BasePoolable item)
        {
            item.OnDespawn(_poolStorage);
        }

        private void OnTakeFromPool(BasePoolable item)
        {
            item.gameObject.SetActive(true);
        }

        private void OnDestroyPoolObject(BasePoolable item)
        {
            Object.Destroy(item.gameObject);
        }

        public void Clear()
        {
            foreach (var pool in _pools.Values)
            {
                if(pool is IDisposable disposablePool)
                    disposablePool.Dispose();
            }
            _pools.Clear();
        }
    }
}

    
