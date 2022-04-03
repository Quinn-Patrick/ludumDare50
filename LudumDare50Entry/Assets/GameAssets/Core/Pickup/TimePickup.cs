using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class TimePickup : PoolableObject, IPickup
    {
        [SerializeField] private float _timeAmount;
        [SerializeField] private float _maxLifeTime;
        private float _lifeTime;
        public void OnCollect(GameObject collider)
        {
            Timer.Instance.AddTime(_timeAmount);
            Pool.PoolObject(this);
        }
        private void OnEnable()
        {
            LevelManager.Instance.LevelProgressed += () => Pool.PoolObject(this);
            _lifeTime = 0f;
        }
        private void OnDisable()
        {
            LevelManager.Instance.LevelProgressed -= () => Pool.PoolObject(this);
        }
        private void FixedUpdate()
        {
            transform.eulerAngles += new Vector3(0f, 0f, 180f * Time.fixedDeltaTime);
            _lifeTime += Time.fixedDeltaTime;
            if(_lifeTime >= _maxLifeTime)
            {
                Pool.PoolObject(this);
            }
        }
    }
}