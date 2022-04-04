using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public abstract class DistanceSoundPlayer : MonoBehaviour
    {
        [SerializeField]protected AudioSource _source;
        protected AudioListener _listener;
        private void Awake()
        {
            _listener = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
        }
        public void PlaySound(AudioClip _clip)
        {
            float distance = Vector2.Distance(transform.position, _listener.transform.position);
            _source.volume = (1 / Mathf.Pow(distance / 20, 2));
            if (_source.volume > 1) _source.volume = 1;
            _source.PlayOneShot(_clip);
        }
    }
}