using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class GunPickupSound : DistanceSoundPlayer
    {
        [SerializeField] private GunPickup _pickup;
        [SerializeField] private AudioClip _clip;

        private Transform _parentTransform;

        private void OnEnable()
        {
            _parentTransform = _source.transform.parent;
            _source.transform.parent = null;
            _pickup.pickedUp += () => PlaySound(_clip);
        }
        private void OnDisable()
        {
            _pickup.pickedUp -= () => PlaySound(_clip);
        }
        private void FixedUpdate()
        {
            _source.transform.position = _parentTransform.position;
        }
    }
}