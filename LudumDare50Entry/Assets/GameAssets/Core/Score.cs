using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class Score : MonoBehaviour
    {
        public static Score Instance;
        private int _score;
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
        public string GetFormattedScore()
        {
            return $"{_score:00000000}";
        }
        public void GainScoreTimeBonus(int baseScore)
        {
            _score += GetTimeBonusScoreValue(baseScore);
        }
        public int GetTimeBonusScoreValue(int baseScore)
        {
            return baseScore * Mathf.FloorToInt(Mathf.Pow(Timer.Instance.GetElapsedTime() / 2, 2));
        }
        public void GainScore(int baseScore)
        {
            _score += baseScore;
        }
        public void ResetScore()
        {
            _score = 0;
        }
    }
}