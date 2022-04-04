using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuinnLD.Core;

namespace QuinnLD.GUI
{
    public class WhiteDissolve : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private AudioSource _audio;
        private void OnEnable()
        {
            LevelManager.Instance.LevelProgressed += ActivateAnimation;
        }
        private void OnDisable()
        {
            LevelManager.Instance.LevelProgressed -= ActivateAnimation;
        }

        private void ActivateAnimation()
        {
            _anim.SetTrigger("NewLevel");
        }
        private void PlayClip()
        {
            _audio.Play();
        }
    }
}