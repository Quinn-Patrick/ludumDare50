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
        private void Awake()
        {
            _playerControls = new Controls();
            _playerControls.Gameplay.UpDown.performed += ctx => UpDown = ctx.ReadValue<float>();
            _playerControls.Gameplay.LeftRight.performed += ctx => LeftRight = ctx.ReadValue<float>();

            _playerControls.Gameplay.UpDown.canceled += ctx => UpDown = 0f;
            _playerControls.Gameplay.LeftRight.canceled += ctx => LeftRight = 0f;
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