using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class BigAsteroidHitAudio : DistanceSoundPlayer
    {
        [SerializeField] private Fatty _asteroid;
        [SerializeField] private AudioClip _hitSound;

        private void OnEnable()
        {
            _asteroid.WasHit += () => PlaySound(_hitSound);
        }
        private void OnDisable ()
        {
            _asteroid.WasHit -= () => PlaySound(_hitSound);
        }
    }
}