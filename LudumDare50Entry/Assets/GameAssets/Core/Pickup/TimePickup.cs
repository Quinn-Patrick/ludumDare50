using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuinnLD.Core
{
    public class TimePickup : MonoBehaviour, IPickup
    {
        [SerializeField] private float _timeAmount;
        public void OnCollect()
        {
            Timer.Instance.AddTime(_timeAmount);
            Destroy(gameObject);
        }
    }
}