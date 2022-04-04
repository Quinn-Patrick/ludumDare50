using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuinnLD.Core;
using UnityEngine.SceneManagement;

namespace QuinnLD.GUI
{
    public class LevelEndWipe : MonoBehaviour
    {
        [SerializeField] Animator _anim;
        [SerializeField] private GameBase _base;
        private void FixedUpdate()
        {
            if(Timer.Instance.GetRemainingTime() <= 0)
            {
                _anim.SetTrigger("LevelOver");
            }
        }
        public void GameOver()
        {
            
        }
    }
}