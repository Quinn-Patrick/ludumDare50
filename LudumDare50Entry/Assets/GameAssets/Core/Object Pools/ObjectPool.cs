using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class ObjectPool: MonoBehaviour
    {
        private Queue<PoolableObject> _objectQueue = new Queue<PoolableObject>();
        [SerializeField] private int _poolSize;
        [SerializeField] private PoolableObject _objectTemplate;
        private void Awake()
        {
            for (int i = 0; i < _poolSize; i++)
            {
                PoolableObject newObject = Instantiate(_objectTemplate.gameObject).GetComponent<PoolableObject>();
                PoolObject(newObject);
                newObject.Pool = this;
            }
        }
        public void PoolObject(PoolableObject obj)
        {
            obj.gameObject.SetActive(false);
            _objectQueue.Enqueue(obj);
        }

        public PoolableObject UnpoolObject()
        {
            if (_objectQueue.Count == 0) return null;
            PoolableObject obj = _objectQueue.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        
    }
}