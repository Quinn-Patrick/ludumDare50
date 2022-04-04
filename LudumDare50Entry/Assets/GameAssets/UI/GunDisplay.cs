using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using QuinnLD.Core;

namespace QuinnLD.GUI
{
    public class GunDisplay : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private GunManager _gun;

        private void Update()
        {
            _text.text = $"Gun: {_gun.GetGunLevel() + 1:0}";
        }
    }
}
