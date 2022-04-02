using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class PlayerCollector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            IPickup pickup = collision.GetComponent<IPickup>();

            if (pickup == null) return;

            pickup.OnCollect();
        }
    }
}