using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class PlayerControls : MonoBehaviour
    {
        private Controls _playerControls;
        public float UpDown;
        public float LeftRight;
        public bool Shooting;
        public bool Dashing;
        public bool Advancing;
        private void Awake()
        {
            _playerControls = new Controls();
            _playerControls.Gameplay.UpDown.performed += ctx => UpDown = ctx.ReadValue<float>();
            _playerControls.Gameplay.LeftRight.performed += ctx => LeftRight = ctx.ReadValue<float>();
            _playerControls.Gameplay.Shoot.performed += ctx => Shooting = true;
            _playerControls.Gameplay.Dash.performed += ctx => Dashing = true;
            _playerControls.Gameplay.Advance.performed += ctx => Advancing = true;

            _playerControls.Gameplay.UpDown.canceled += ctx => UpDown = 0f;
            _playerControls.Gameplay.LeftRight.canceled += ctx => LeftRight = 0f;
            _playerControls.Gameplay.Shoot.canceled += ctx => Shooting = false;
            _playerControls.Gameplay.Dash.canceled += ctx => Dashing = false;
            _playerControls.Gameplay.Advance.canceled += ctx => Advancing = false;
        }
        private void OnEnable()
        {
            _playerControls.Gameplay.Enable();
        }
        private void OnDisable()
        {
            _playerControls.Gameplay.Disable();
        }
        
    }
}