using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Domino : PlaceableItem
{
    protected override void Awake()
    {
        base.Awake();
        weight = 0.5f;
        friction = 1.0f;
        OnSetup();
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
