using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class Exhaust : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        private void Awake()
        {
            _source.Play();
            _source.volume = transform.localScale.x * 0.5f;
        }
        private void FixedUpdate()
        {
            _source.volume = transform.localScale.x * 0.5f;
        }
    }
}