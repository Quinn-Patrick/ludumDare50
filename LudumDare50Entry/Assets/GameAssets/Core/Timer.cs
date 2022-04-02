using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class Timer : MonoBehaviour
    {
        public static Timer Instance;
        private float _currentTime = 0f;
        [SerializeField] private float _startTime;
        private void Awake()
        {
            _currentTime = _startTime;
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
        private void Update()
        {
            _currentTime -= Time.deltaTime;
        }
        public string GetFormattedTime()
        {
            return $"{(int)_currentTime / 60:0}:{(int)_currentTime % 60:00}.{GetFractionalSeconds():00}";
            
        }
        private int GetFractionalSeconds()
        {
            return Mathf.FloorToInt((_currentTime - Mathf.Floor(_currentTime)) * 100);
        }
        public void AddTime(float timeAmount)
        {
            _currentTime += timeAmount;
        }
    }
}