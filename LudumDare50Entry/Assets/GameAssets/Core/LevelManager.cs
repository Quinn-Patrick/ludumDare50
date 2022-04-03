using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class LevelManager : MonoBehaviour
    {
        private int _level = 0;
        public int ActiveAsteroids;
        public static LevelManager Instance;
        public int MaxAsteroids;
        public bool GoalCollected;

        public List<AsteroidSpawn> AsteroidSpawners = new List<AsteroidSpawn>();

        public delegate void LevelProgressionHandler();
        public event LevelProgressionHandler LevelProgressed;

        [SerializeField] private PlayerControls _input;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            AdvanceLevel();
        }

        public void AdvanceLevel()
        {
            Score.Instance.GainScoreTimeBonus(100 * _level);
            _level++;
            GoalCollected = false;
            MaxAsteroids = (_level + 1) * 10;
             if (MaxAsteroids > 100) MaxAsteroids = 100;
            LevelProgressed?.Invoke();

            List<Asteroid> newAsteroids = new List<Asteroid>();
            while (ActiveAsteroids < MaxAsteroids)
            {
                if (AsteroidSpawners.Count > 0)
                {
                    newAsteroids.Add(AsteroidSpawners[Random.Range(0, AsteroidSpawners.Count - 1)].SpawnAsteroidAnywhere());
                }
            }
            newAsteroids[Random.Range(0, newAsteroids.Count - 1)].SetDrop(Pickups.MissionCompleter);
        }
        private void FixedUpdate()
        {
            EnsureAsteroidSpawnerList();

            if (GoalCollected)
            {
                if (_input.Advancing)
                {
                    AdvanceLevel();
                }
            }
            if (ActiveAsteroids < MaxAsteroids && AsteroidSpawners.Count > 0)
            {
                AsteroidSpawners[Random.Range(0, AsteroidSpawners.Count)].SpawnAsteroid();
            }
        }

        private void EnsureAsteroidSpawnerList()
        {
            if (AsteroidSpawners.Count > 0)
            {
                if (AsteroidSpawners[0] == null) AsteroidSpawners.Clear();
            }
        }
        public int GetLevel()
        {
            return _level;
        }
    }
}