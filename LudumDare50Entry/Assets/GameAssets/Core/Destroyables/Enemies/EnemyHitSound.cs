using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class EnemyHitSound : DistanceSoundPlayer
    {
        [SerializeField] private Enemy _enemy;
        [SerializeField] private AudioClip _hitSound;

        private void OnEnable()
        {
            _enemy.WasHit += () => PlaySound(_hitSound);
        }
        private void OnDisable()
        {
            _enemy.WasHit -= () => PlaySound(_hitSound);
        }
    }
}