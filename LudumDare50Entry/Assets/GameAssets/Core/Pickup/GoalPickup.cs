using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class GoalPickup : MonoBehaviour, IPickup
    {
        private void Awake()
        {
            gameObject.transform.position = new Vector2(9999, 9999);
        }
        public void OnCollect(GameObject collider)
        {
            gameObject.transform.position = new Vector2(9999, 9999);
            LevelManager.Instance.GoalCollected = true;
        }
    }
}