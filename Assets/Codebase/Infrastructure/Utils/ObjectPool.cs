using System.Collections.Generic;
using UnityEngine;

namespace Codebase.Infrastructure.Utils
{
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private readonly Queue<T> _pool = new();
        private readonly T _prefab;
        private readonly Transform _parent;

        public ObjectPool(T prefab, int initialSize, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                ReturnToPool(CreateNewObject());
            }
        }

        private T CreateNewObject()
        {
            T newObj = Object.Instantiate(_prefab, _parent);
            newObj.gameObject.SetActive(false);
            return newObj;
        }

        public T GetFromPool()
        {
            if (_pool.Count == 0)
            {
                return CreateNewObject();
            }

            T obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void ReturnToPool(T obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}