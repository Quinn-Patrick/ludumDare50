using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using QuinnLD.Core;

namespace QuinnLD.GUI
{
    public class ElapsedTimeDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Update()
        {
            _text.text = $"Elapsed: {Timer.Instance.GetFormattedTimeElapsed()}";
        }
    }
}