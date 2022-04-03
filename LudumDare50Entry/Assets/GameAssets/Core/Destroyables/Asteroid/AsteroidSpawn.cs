using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class AsteroidSpawn : MonoBehaviour
    {
        private ObjectPool _asteroidPool;
        private ObjectPool _fattyPool;
        private ObjectPool _enemyPool;
        [SerializeField] private GameObject _origin;
        [SerializeField] private float _minimumDistance;
        private void Awake()
        {
            LevelManager.Instance.AsteroidSpawners.Add(this);
            _origin = GameObject.FindGameObjectsWithTag("Player")[0];
            _asteroidPool = GameObject.FindGameObjectsWithTag("AsteroidPool")[0].GetComponent<ObjectPool>();
            _fattyPool = GameObject.FindGameObjectsWithTag("FattyPool")[0].GetComponent<ObjectPool>();
            _enemyPool = GameObject.FindGameObjectsWithTag("EnemyPool")[0].GetComponent<ObjectPool>();
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        }
        
        public Asteroid SpawnAsteroid()
        {
            float distance = Vector2.Distance(transform.position, _origin.transform.position);
            if (distance > _minimumDistance)
            {
                return SpawnAsteroidAnywhere();
            }
            return null;
        }
        public Asteroid SpawnAsteroidAnywhere()
        {
            if (_asteroidPool == null) return null;
            
            PoolableObject asteroid = ChooseObjectType();
            
            asteroid.transform.position = transform.position;
            return asteroid.GetComponent<Asteroid>();
        }

        private PoolableObject ChooseObjectType()
        {
            PoolableObject asteroid = null;
            float roll = Random.Range(0f, 1f);
            if (LevelManager.Instance.GetLevel() < 3)
            {
                if (roll < 0.9f)
                {
                    asteroid = _asteroidPool.UnpoolObject();
                }
                else
                {
                    asteroid = _fattyPool.UnpoolObject();
                }
            }
            else if (LevelManager.Instance.GetLevel() < 6)
            {
                if (roll < 0.8f)
                {
                    asteroid = _asteroidPool.UnpoolObject();
                }
                else if (roll < 0.9f)
                {
                    asteroid = _fattyPool.UnpoolObject();
                }
                else
                {
                    asteroid = _enemyPool.UnpoolObject();
                }
            }
            else if (LevelManager.Instance.GetLevel() < 12)
            {
                if (roll < 0.7f)
                {
                    asteroid = _asteroidPool.UnpoolObject();
                }
                else if (roll < 0.8f)
                {
                    asteroid = _fattyPool.UnpoolObject();
                }
                else
                {
                    asteroid = _enemyPool.UnpoolObject();
                }
            }
            else
            {
                if (roll < 0.6f)
                {
                    asteroid = _asteroidPool.UnpoolObject();
                }
                else if (roll < 0.7f)
                {
                    asteroid = _fattyPool.UnpoolObject();
                }
                else
                {
                    asteroid = _enemyPool.UnpoolObject();
                }
            }
            return asteroid;
        }
    }
}