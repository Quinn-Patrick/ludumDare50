using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class GunPickup : PoolableObject, IPickup
    {
        private float _lifetime = 0;
        private float _lifetimeLimit = 15;

        public delegate void PickupHandler();
        public event PickupHandler pickedUp;
        private void OnEnable()
        {
            LevelManager.Instance.LevelProgressed += PoolThis;
            _lifetime = 0f;
        }
        private void OnDisable()
        {
            LevelManager.Instance.LevelProgressed -= PoolThis;
        }

        private void PoolThis()
        {
            Pool.PoolObject(this);
        }
        public void OnCollect(GameObject collider)
        {
            pickedUp?.Invoke();
            GunManager gun = collider.GetComponent<GunManager>();
            if (gun == null) return;
            gun.IncreaseGunLevel();
            Remove();
        }
        private void FixedUpdate()
        {
            _lifetime += Time.fixedDeltaTime;
            if(_lifetime > _lifetimeLimit)
            {
                Remove();   
            }
        }
        private void Remove()
        {
            _lifetime = 0;
            Pool.PoolObject(this);
        }
    }
}