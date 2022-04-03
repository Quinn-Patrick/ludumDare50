using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class GunPickup : PoolableObject, IPickup
    {
        private float _lifetime = 0;
        private float _lifetimeLimit = 15;
        private void OnEnable()
        {
            LevelManager.Instance.LevelProgressed += () => Pool.PoolObject(this);
        }
        private void OnDisable()
        {
            LevelManager.Instance.LevelProgressed += () => Pool.PoolObject(this);
        }
        public void OnCollect(GameObject collider)
        {
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