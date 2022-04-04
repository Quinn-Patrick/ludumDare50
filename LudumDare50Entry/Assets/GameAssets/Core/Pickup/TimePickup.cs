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

        public delegate void PickupHandler();
        public event PickupHandler pickedUp;
        public void OnCollect(GameObject collider)
        {
            pickedUp?.Invoke();
            Timer.Instance.AddTime(_timeAmount);
            Pool.PoolObject(this);
        }
        private void OnEnable()
        {
            LevelManager.Instance.LevelProgressed += PoolThis;
            _lifeTime = 0f;
        }
        private void OnDisable()
        {
            LevelManager.Instance.LevelProgressed -= PoolThis;
        }

        private void PoolThis()
        {
            Pool.PoolObject(this);
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