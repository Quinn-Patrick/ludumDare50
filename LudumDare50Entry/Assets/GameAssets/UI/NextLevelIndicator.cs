using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuinnLD.Core;

namespace QuinnLD.GUI
{
    public class NextLevelIndicator : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        private void FixedUpdate()
        {
            _anim.SetBool("IsReady", LevelManager.Instance.GoalCollected);
        }
    }
}