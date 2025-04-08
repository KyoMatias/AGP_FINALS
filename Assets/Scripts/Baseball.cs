using UnityEngine;

public class Baseball : PlaceableItem
{
    protected override void Awake()
    {
        base.Awake();
        itemName = "Baseball";
        description = "A lightweight baseball. Rolls easily.";
        weight = 0.5f;
        friction = 0.3f;
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