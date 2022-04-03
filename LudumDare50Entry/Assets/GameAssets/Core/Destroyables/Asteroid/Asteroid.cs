using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class Asteroid : Destroyable
    {
        protected Rigidbody2D _body;
        private void Awake()
        {
            _body = GetComponent<Rigidbody2D>();
        }
        private void OnEnable()
        {
            LevelManager.Instance.LevelProgressed += () => Remove();
            ChooseDrop();

            RandomizeStartingMovement();

            LevelManager.Instance.ActiveAsteroids++;
        }
        private void OnDisable()
        {
            LevelManager.Instance.LevelProgressed -= () => Remove();
            LevelManager.Instance.ActiveAsteroids--;
        }
        private void RandomizeStartingMovement()
        {
            float range = 2f;
            if(LevelManager.Instance.GetLevel() > 2)
            {
                range = 4f;
            }
            else if (LevelManager.Instance.GetLevel() > 5)
            {
                range = 8f;
            }
            else if (LevelManager.Instance.GetLevel() > 10)
            {
                range = 16f;
            }

            _body.velocity = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
            _body.angularVelocity = Random.Range(-90, 90);
        }
        protected virtual void ChooseDrop()
        {
            float odds = 1 - (3f / (float)LevelManager.Instance.MaxAsteroids);
            float roll = Random.Range(0f, 100f);
            if (roll > odds * 100)
            {
                _drop = Pickups.TimeExtender;
            }
            else
            {
                odds = 1 - (1.5f / (float)LevelManager.Instance.MaxAsteroids);
                roll = Random.Range(0f, 100f);
                if (roll > odds * 100)
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
}