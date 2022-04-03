using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class GunSound : DistanceSoundPlayer
    {
        [SerializeField] private AudioClip _gun1Clip;
        [SerializeField] private AudioClip _gun2Clip;
        [SerializeField] private AudioClip _gun3Clip;
        [SerializeField] private Gun _gun;
        [SerializeField] private GunLevel2 _gun2;
        [SerializeField] private GunLevel3 _gun3;
        private void OnEnable()
        {
            _gun.Shot += () => PlaySound(_gun1Clip);
            _gun2.Shot += () => PlaySound(_gun2Clip);
            _gun3.Shot += () => PlaySound(_gun3Clip);
        }
        private void OnDisable()
        {
            _gun.Shot -= () => PlaySound(_gun1Clip);
            _gun2.Shot -= () => PlaySound(_gun2Clip);
            _gun3.Shot -= () => PlaySound(_gun3Clip);
        }

    }
}