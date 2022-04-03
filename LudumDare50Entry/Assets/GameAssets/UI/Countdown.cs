using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using QuinnLD.Core;

namespace QuinnLD.GUI
{
    public class Countdown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Animator _anim;
        private void FixedUpdate()
        {
            string lastText = _text.text;
            float remainingTime = Timer.Instance.GetRemainingTime();
            if(remainingTime < 6 && remainingTime >= 0)
            {
                _text.text = $"{Mathf.FloorToInt(remainingTime)}";
            }
            else if (remainingTime >= 6)
            {
                _text.text = "";
            }
            else
            {
                _text.text = $"0";
            }
            if(_text.text != lastText)
            {
                _anim.SetTrigger("NewNumber");
            }
        }
    }
}