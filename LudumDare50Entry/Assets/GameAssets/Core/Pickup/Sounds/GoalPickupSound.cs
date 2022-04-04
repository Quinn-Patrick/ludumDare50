using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class GoalPickupSound : DistanceSoundPlayer
    {
        [SerializeField] private GoalPickup _goal;
        [SerializeField] private AudioClip _clip;
        private Transform _parentTransform;

        private void OnEnable()
        {
            _parentTransform = _source.transform.parent;
            _source.transform.parent = null;
            _goal.pickedUp += () => PlaySound(_clip);
        }
        private void OnDisable()
        {
            _goal.pickedUp -= () => PlaySound(_clip);
        }
        private void FixedUpdate()
        {
            _source.transform.position = _parentTransform.position;
        }
    }
}