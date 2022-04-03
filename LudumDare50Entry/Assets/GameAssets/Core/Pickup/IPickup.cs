using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickup
{
    public void OnCollect(GameObject collider);
}
