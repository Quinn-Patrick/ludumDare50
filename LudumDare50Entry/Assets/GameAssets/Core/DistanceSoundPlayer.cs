using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public abstract class DistanceSoundPlayer : MonoBehaviour
    {
        [SerializeField]protected AudioSource _source;
        protected AudioListener _listener;
        private List<AudioClip> _clipsPlayedThisFrame = new List<AudioClip>();
        private void Awake()
        {
            _listener = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioListener>();
        }
        protected void Update()
        {
            float distance = Vector2.Distance(transform.position, _listener.transform.position);
            _source.volume = (1 / Mathf.Pow(distance / 10, 2));
            if (_source.volume > 1) _source.volume = 1;
            _clipsPlayedThisFrame.Clear();
        }
        public void PlaySound(AudioClip _clip)
        {
            if (_clipsPlayedThisFrame.Contains(_clip))
            {
                return;
            }
            _source.PlayOneShot(_clip);
            _clipsPlayedThisFrame.Add(_clip);
        }
    }
}