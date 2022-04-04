using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class DestroyableAudio : DistanceSoundPlayer
    {
        [SerializeField] private Destroyable _dest;
        [SerializeField] private AudioClip _hitClip;
        [SerializeField] private AudioClip _destroyedClip;

        private Transform _parentTransform;

        private void OnEnable()
        {
            _parentTransform = _source.transform.parent;
            _source.transform.parent = null;

            _dest.WasHit += PlayHitClip;
            _dest.Killed += () => PlaySound(_destroyedClip);
        }
        private void OnDisable()
        {
            _dest.WasHit -= PlayHitClip;
            _dest.Killed -= () => PlaySound(_destroyedClip);
        }
        private void PlayHitClip()
        {
            PlaySound(_hitClip);
        }

        private void FixedUpdate()
        {
            _source.transform.position = _parentTransform.position;
        }
    }
}