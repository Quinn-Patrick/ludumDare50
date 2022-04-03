using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class Fatty : Asteroid
    {
        private int _health = 10;

        new public delegate void HitHandler();
        new public event HitHandler WasHit;
        override public void OnHit()
        {
            WasHit?.Invoke();
            _health--;
            if (_health <= 0) Die();
        }

        private void Die()
        {
            _health = 10;
            _baseScore = 1000;
            GetDrop();
            _drop = Pickups.None;
            Score.Instance.GainScore(_baseScore * LevelManager.Instance.GetLevel());
            Remove();
        }

        override protected void ChooseDrop()
        {
            float odds = 1 - (10f / (float)LevelManager.Instance.MaxAsteroids);
            float roll = Random.Range(0f, 100f);
            if (roll > odds * 100)
            {
                _drop = Pickups.TimeExtender;
            }
            else
            {
                odds = 1 - (10f / (float)LevelManager.Instance.MaxAsteroids);
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