using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class RotatingWall : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _body;
        private void FixedUpdate()
        {
            _body.angularVelocity = 45f;
        }
    }
}