using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStop : PlaceableItem
{
    protected override void Awake()
    {
        base.Awake();
        weight = 2f;
        friction = 1.0f;
    }

    public override void OnSetup()
    {
        base.OnSetup();
    }

    public override void OnActivate()
    {
        base.OnActivate();
    }

}
