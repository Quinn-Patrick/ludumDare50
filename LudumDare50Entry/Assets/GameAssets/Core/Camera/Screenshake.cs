using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class Screenshake : MonoBehaviour
    {
        public static Screenshake Instance;
        private float _shake;
        private float _shakeDecay = 5f;
        private float _maxShake = 1.5f;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
        public void AddScreenshake(float shakeAmount)
        {
            _shake += shakeAmount;
            EnsureScreenshake();
        }
        public float GetScreenShake()
        {
            return _shake;
        }
        private void FixedUpdate()
        {
            if(_shake > 0)
            {
                _shake -= _shakeDecay * Time.fixedDeltaTime;
            }
            EnsureScreenshake();
        }
        private void EnsureScreenshake()
        {
            if (_shake > _maxShake) _shake = _maxShake;
            if (_shake < 0) _shake = 0;
        }
    }
}