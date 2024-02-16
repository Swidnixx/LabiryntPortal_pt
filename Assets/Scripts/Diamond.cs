using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Pickup
{
    protected override void Pick()
    {
        base.Pick(); // u¿ycie podstawowej wersji tej funkcji
        GameManager.Instance.PickDiamond();
    }
}
