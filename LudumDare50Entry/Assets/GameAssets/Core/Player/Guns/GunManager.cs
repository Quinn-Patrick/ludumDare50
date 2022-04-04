using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class GunManager : MonoBehaviour
    {
        private int _gunLevel;
        private float _gunTime = 0;
        private float _maxGunTime = 10f;

        private void FixedUpdate()
        {
            _gunTime -= Time.fixedDeltaTime;
            if(_gunTime <= 0)
            {
                _gunLevel--;
                if (_gunLevel <= 0)
                {
                    _gunLevel = 0;
                    _gunTime = 0f;
                }
                else _gunTime = _maxGunTime;
            }
        }

        public void IncreaseGunLevel()
        {
            _gunLevel++;
            _gunTime = _maxGunTime;
            if(_gunLevel > 2)
            {
                _gunLevel = 2;
            }
        }
        public float GetGunLevel()
        {
            return _gunLevel;
        }
        public float GetGunTime()
        {
            return _gunTime;
        }
    }
}