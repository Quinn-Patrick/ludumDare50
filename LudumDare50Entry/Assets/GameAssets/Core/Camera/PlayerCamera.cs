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
            float shake = Screenshake.Instance.GetScreenShake();
            transform.position = new Vector3(_player.transform.position.x + Random.Range(-shake, shake), _player.transform.position.y + Random.Range(-shake, shake), -30);
        }
    }
}