using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuinnLD.Core;

namespace QuinnLD.GUI
{ 
    public class GunGuage : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        [SerializeField] private RectTransform _gauge;
        [SerializeField] private GunManager _gun;

        private void FixedUpdate()
        {
            _anim.SetBool("PanelDeployed", _gun.GetGunLevel() > 0);
            _gauge.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _gun.GetGunTime() / 10f * 160);
        }

    }
}