using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class AsteroidDestructionParticles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particles;
        [SerializeField] private Destroyable _asteroid;

        private void OnEnable()
        {
            transform.parent = null;
            _asteroid.Killed += ActivateParticles;
        }
        private void OnDisable()
        {
            _asteroid.Killed -= ActivateParticles;
        }

        private void ActivateParticles()
        {
            transform.position = _asteroid.transform.position;
            _particles.Play();
        }
    }
}