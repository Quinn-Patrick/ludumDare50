using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using QuinnLD.Core;

namespace QuinnLD.GUI
{
    public class TimerDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Update()
        {
            _text.text = $"Time: {Timer.Instance.GetFormattedTime()}";
        }
    }
}