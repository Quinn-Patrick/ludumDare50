using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class GunLevel3 : MonoBehaviour
    {
        [SerializeField] private ObjectPool _pool;
        [SerializeField] private PlayerControls _input;
        [SerializeField] private GunManager _manager;
        private Rigidbody2D _body;
        private float _shootCountdown;
        private bool _canShoot = true;

        public delegate void ShotHandler();
        public event ShotHandler Shot;
        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_manager.GetGunLevel() >= 2)
            {
                if (_input.Shooting)
                {
                    if (_canShoot)
                    {
                        ProjectBullet(new Vector3(-1 * Mathf.Sin(Mathf.Deg2Rad * _body.transform.eulerAngles.z), 1 * Mathf.Cos(Mathf.Deg2Rad * _body.transform.eulerAngles.z), 0), -25);
                        ProjectBullet(new Vector3(1 * Mathf.Sin(Mathf.Deg2Rad * _body.transform.eulerAngles.z), -1 * Mathf.Cos(Mathf.Deg2Rad * _body.transform.eulerAngles.z), 0), 25);
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

        private void ProjectBullet(Vector3 offset, float angleOffset)
        {
            PoolableObject obj = _pool.UnpoolObject();
            obj.transform.position = gameObject.transform.position + offset;
            Bullet bullet = obj.GetComponent<Bullet>();
            if (bullet != null)
            {
                Shot?.Invoke();
                bullet.SetVelocity(Mathf.Deg2Rad * transform.eulerAngles.z + angleOffset, _body);
            }
            _canShoot = false;
            _shootCountdown = 0.08f;
        }
    }
}