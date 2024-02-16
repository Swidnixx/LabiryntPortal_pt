using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Pickup
{
    public int timeToAdd = 10;

    protected override void Pick()
    {
        base.Pick();
        GameManager.Instance.AddTime(timeToAdd);
    }
}
