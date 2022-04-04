using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuinnLD.Core;
using TMPro;

namespace QuinnLD.GUI
{
    public class BonusScoreReadout : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private void FixedUpdate()
        {
            if (Score.Instance == null) return;
            if (LevelManager.Instance == null) return;
            _text.text = $"Bonus: {Score.Instance.GetTimeBonusScoreValue(LevelManager.Instance.GetLevel() * 100)}";
        }
    }
}