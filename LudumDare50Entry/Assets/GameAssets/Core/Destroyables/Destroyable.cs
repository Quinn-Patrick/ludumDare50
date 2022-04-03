using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public abstract class Destroyable : PoolableObject
    {
        protected Pickups _drop;
        [SerializeField] protected int _baseScore;

        public delegate void HitHandler();
        public event HitHandler WasHit;

        public delegate void DeathHandler();
        public event DeathHandler Killed;
        public virtual void OnHit()
        {
            WasHit?.Invoke();
            GetDrop();
            _drop = Pickups.None;
            Score.Instance.GainScore(_baseScore * LevelManager.Instance.GetLevel());
            Remove();
        }

        public void SetDrop(Pickups pickup)
        {
            _drop = pickup;
        }
        private void Update()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }

        protected void GetDrop()
        {
            switch (_drop)
            {
                case Pickups.TimeExtender:
                {
                    ObjectPool _pool = GameObject.FindGameObjectsWithTag("TimePickupPool")[0].GetComponent<ObjectPool>();
                    PoolableObject drop = _pool.UnpoolObject();
                    drop.transform.position = transform.position;
                    break;
                }
                case Pickups.GunPowerup:
                {
                    ObjectPool _pool = GameObject.FindGameObjectsWithTag("GunPowerupPool")[0].GetComponent<ObjectPool>(); ;
                    PoolableObject drop = _pool.UnpoolObject();
                    drop.transform.position = transform.position;
                    break;
                }
                case Pickups.MissionCompleter:
                {
                    GameObject pickup = GameObject.FindGameObjectsWithTag("GoalPickup")[0];
                    pickup.transform.position = transform.position;
                    break;
                }
                default: break;
            }
        }
        public virtual void Remove()
        {
            Killed?.Invoke();
            Pool.PoolObject(this);
        }
    }
}