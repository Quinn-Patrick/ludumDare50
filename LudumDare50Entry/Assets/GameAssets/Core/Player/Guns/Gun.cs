using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private ObjectPool _pool;
        [SerializeField] private PlayerControls _input;
        private Rigidbody2D _body;
        private bool _canShoot = true;
        private float _shootCountdown;

        public delegate void ShotHandler();
        public event ShotHandler Shot;
        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_input.Shooting)
            {
                if (_canShoot)
                {
                    PoolableObject obj = _pool.UnpoolObject();
                    obj.transform.position = gameObject.transform.position;
                    Bullet bullet = obj.GetComponent<Bullet>();
                    if(bullet != null)
                    {
                        Shot?.Invoke();
                        bullet.SetVelocity(Mathf.Deg2Rad * transform.eulerAngles.z, _body);
                    }
                    _canShoot = false;
                    _shootCountdown = 0.08f;
                }
                else
                {
                    _shootCountdown -= Time.fixedDeltaTime;
                    if (_shootCountdown <= 0)
                    {
                        _canShoot = true;
                    }
                }
            }
            else
            {
                _canShoot = true;
            }
        }
    }
}