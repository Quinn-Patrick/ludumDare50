using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerControls _controls;
        [SerializeField] private Rigidbody2D _body;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _friction;

        private void FixedUpdate()
        {
            _body.AddForce(_acceleration * Time.fixedDeltaTime * new Vector2(_controls.LeftRight, _controls.UpDown), ForceMode2D.Impulse);
            ApplyFriction();
            EnsureVelocity();
        }

        private void EnsureVelocity()
        {
            if(_body.velocity.magnitude > _maxSpeed)
            {
                _body.velocity = _maxSpeed * _body.velocity.normalized;
            }
            if(_body.velocity.magnitude < 0.1f)
            {
                _body.velocity = Vector2.zero;
            }
        }

        private void ApplyFriction()
        {
            if (Mathf.Abs(_controls.LeftRight) <= float.Epsilon && Mathf.Abs(_controls.UpDown) <= float.Epsilon)
            {
                if(_body.velocity.magnitude < _friction * Time.deltaTime)
                {
                    _body.velocity = Vector2.zero;
                    return;
                }
                _body.AddForce(_friction * Time.fixedDeltaTime * -_body.velocity.normalized, ForceMode2D.Impulse);
            }
        }
    }
}