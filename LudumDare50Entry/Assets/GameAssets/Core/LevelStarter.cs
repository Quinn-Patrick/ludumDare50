using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] private AudioSource _levelMusic;
        
        private void Start()
        {
            if(LevelManager.Instance != null)
            {
                LevelManager.Instance.ResetLevel();
                LevelManager.Instance.AdvanceLevel();
            }
        }
        private void OnDestroy()
        {
            StopMusic();
        }
        private void StopMusic()
        {
            _levelMusic.Stop();
        }
    }
}