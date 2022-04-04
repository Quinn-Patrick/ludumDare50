using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class Enemy : Asteroid
    {
        [SerializeField] private ObjectPool _bulletPool;
        private float _shotInterval = 5;
        private float _timeUntilShot;
        private int _health = 5;

        new public delegate void HitHandler();
        new public event HitHandler WasHit;
        override public void OnHit()
        {
            Screenshake.Instance.AddScreenshake(0.1f);
            WasHit?.Invoke();
            _health--;
            if (_health <= 0) Die();
        }

        private void Die()
        {
            Screenshake.Instance.AddScreenshake(1f);
            _health = 5;
            _baseScore = 500;
            GetDrop();
            _drop = Pickups.None;
            Score.Instance.GainScore(_baseScore * LevelManager.Instance.GetLevel());
            Kill();
        }
        private void FixedUpdate()
        {
            _timeUntilShot -= Time.fixedDeltaTime;
            if(_timeUntilShot <= 0)
            {
                _timeUntilShot += _shotInterval;
                ShootBullet(transform.eulerAngles.z);
                ShootBullet(transform.eulerAngles.z + 90);
                ShootBullet(transform.eulerAngles.z + 180);
                ShootBullet(transform.eulerAngles.z + 270);
            }
        }

        private void ShootBullet(float angle)
        {
            PoolableObject obj = _bulletPool.UnpoolObject();
            obj.transform.position = gameObject.transform.position;
            Bullet bullet = obj.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.SetVelocity(Mathf.Deg2Rad * angle, _body);
            }
        }

        override protected void ChooseDrop()
        {
            
            float roll = Random.Range(0f, 100f);
            if (roll > 25 && roll < 50)
            {
                _drop = Pickups.TimeExtender;
            }
            else if(roll <= 25)
            {
                _drop = Pickups.GunPowerup;
            }
            else
            {
                _drop = Pickups.None;
            }
        }
    }
}