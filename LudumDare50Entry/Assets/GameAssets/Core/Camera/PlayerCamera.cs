using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private GameObject _player;

        private void Update()
        {
            transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -30);
        }
    }
}