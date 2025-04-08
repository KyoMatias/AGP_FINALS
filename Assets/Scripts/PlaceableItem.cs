using UnityEngine;

public abstract class PlaceableItem : MonoBehaviour
{
    [Header("Item Info")]
    public string itemName;
    public string description;

    [Header("Physics Settings")]
    public float weight = 1f;
    public float friction = 0.5f;

    protected Rigidbody rb;
    protected Collider col;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    public virtual void OnSetup()
    {
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.mass = weight;
        }

        if (col != null && col.material != null)
        {
            col.material.dynamicFriction = friction;
            col.material.staticFriction = friction;
        }
    }

    public virtual void OnActivate()
    {
        if (rb != null)
            rb.isKinematic = false;
    }
}
