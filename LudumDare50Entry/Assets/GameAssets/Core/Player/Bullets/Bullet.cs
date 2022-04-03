using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class Bullet : PoolableObject
    {
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private float _bulletSpeed;
        private float _duration;
        [SerializeField] private float _maxDuration;

        private void OnEnable()
        {
            LevelManager.Instance.LevelProgressed += () => Pool.PoolObject(this);
            _duration = _maxDuration;
        }

        private void FixedUpdate()
        {
            _duration -= Time.fixedDeltaTime;
            if(_duration <= 0)
            {
                Pool.PoolObject(this);
            }
        }

        private void OnDisable()
        {
            _body.velocity = Vector2.zero;
            LevelManager.Instance.LevelProgressed -= () => Pool.PoolObject(this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroyable target = collision.gameObject.GetComponent<Destroyable>();

            if (target != null)
            {
                target.OnHit();
            }
            Pool.PoolObject(this);
        }

        public void SetVelocity(float direction, Rigidbody2D shooter)
        {
            _body.velocity = shooter.velocity;
            _body.AddForce(new Vector2(_bulletSpeed * Mathf.Cos(direction), _bulletSpeed * Mathf.Sin(direction)));
        }
    }
}