using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using QuinnLD.Core;

namespace QuinnLD.GUI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private void Update()
        {
            _text.text = $"Score: {Score.Instance.GetFormattedScore()}";
        }
    }
}
