using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class Timer : MonoBehaviour
    {
        public static Timer Instance;
        private float _timeRemaining = 0f;
        private float _timeElapsed = 0f;
        [SerializeField] private float _startTime;
        private void Awake()
        {
            _timeRemaining = _startTime;
            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnEnable()
        {
            LevelManager.Instance.LevelProgressed += OnLevelProgression;
        }

        private void OnDisable()
        {
            LevelManager.Instance.LevelProgressed -= OnLevelProgression;
        }
        private void OnLevelProgression()
        {
            _timeRemaining = _startTime;
            _timeElapsed = 0;
        }

        private void Update()
        {
            _timeRemaining -= Time.deltaTime;
            _timeElapsed += Time.deltaTime;
        }
        public string GetFormattedTimeRemaining()
        {
            return $"{(int)_timeRemaining / 60:0}:{(int)_timeRemaining % 60:00}.{GetFractionalSeconds(_timeRemaining):00}";
            
        }
        public string GetFormattedTimeElapsed()
        {
            return $"{(int)_timeElapsed / 60:0}:{(int)_timeElapsed % 60:00}.{GetFractionalSeconds(_timeElapsed):00}";

        }
        private int GetFractionalSeconds(float time)
        {
            return Mathf.FloorToInt((time - Mathf.Floor(time)) * 100);
        }
        public void AddTime(float timeAmount)
        {
            if (_timeElapsed > 30) timeAmount /= 2;
            if (_timeElapsed > 60) timeAmount /= 2;
            if (LevelManager.Instance.GetLevel() > 10) timeAmount /= 2;
            if (LevelManager.Instance.GetLevel() > 20) timeAmount /= 2;
            _timeRemaining += timeAmount;
        }
        public float GetElapsedTime()
        {
            return _timeElapsed;
        }
        public float GetRemainingTime()
        {
            return _timeRemaining;
        }
        public void ResetTime()
        {
            _timeRemaining = _startTime;
            _timeElapsed = 0f;
        }
    }
}