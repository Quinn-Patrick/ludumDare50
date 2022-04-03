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
        private float _maxSpeed;
        [SerializeField] private float _friction;

        [SerializeField] private float _baseMaxSpeed;
        [SerializeField] private float _dashMaxSpeed;

        private float _timeOut;

        private void OnEnable()
        {
            LevelManager.Instance.LevelProgressed += () => transform.position = new Vector2(0f, 0f);
        }
        private void OnDisable()
        {
            LevelManager.Instance.LevelProgressed -= () => transform.position = new Vector2(0f, 0f);
        }

        private void FixedUpdate()
        {
            _timeOut -= Time.fixedDeltaTime;
            

            if (_controls.Dashing)
            {
                _maxSpeed = _dashMaxSpeed;
            }
            else
            {
                _maxSpeed = _baseMaxSpeed;
            }

            

            float upDown = _controls.UpDown;
            float leftRight = _controls.LeftRight;
            if(_timeOut > 0)
            {
                upDown = 0;
                leftRight = 0;
            }
            _body.AddForce(_acceleration * Time.fixedDeltaTime * new Vector2(leftRight, upDown), ForceMode2D.Impulse);
            if (Mathf.Abs(upDown) > 0 || Mathf.Abs(leftRight) > 0)
            {
                if (Mathf.Abs(leftRight) < 0.001)
                {
                    leftRight = 0.001f * Mathf.Sign(leftRight);
                }
                transform.eulerAngles = new Vector3(0f, 0f, Mathf.Rad2Deg * Mathf.Atan(upDown / leftRight));
                if (leftRight < 0) transform.eulerAngles += new Vector3(0f, 0f, 180f);
            }
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.relativeVelocity.magnitude > 2f && _timeOut < -0.5f)
            {
                _timeOut = 1f;
            }
        }
    }
}