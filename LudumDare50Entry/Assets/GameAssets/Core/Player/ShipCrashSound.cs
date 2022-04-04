using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class ShipCrashSound : DistanceSoundPlayer
    {
        [SerializeField] private PlayerMover _player;
        [SerializeField] private AudioClip _clip;

        private void OnEnable()
        {
            _player.Impacted += () => PlaySound(_clip);
        }
        private void OnDisable()
        {
            _player.Impacted -= () => PlaySound(_clip);
        }
    }
}