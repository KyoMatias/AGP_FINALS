using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NaughtyAttributes;
using UnityEngine;

public class MoveToyCar : MonoBehaviour
{
   
    [SerializeField] private float distance; // Variable for Distance.
    [SerializeField] private float time;// Variable For Time.
    private Rigidbody rb;// Variable for the GameObject's Rigidbody Component.
    public float Speed;
    public float ActualTime;
    public bool IsStart;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timechecker();
    }

    void Timechecker()
    {
        if(IsStart)
        {
            ActualTime += Time.deltaTime;
            if(ActualTime / time < 0.99f)
            {
                rb.velocity = Speed * Vector3.left;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    [Button]
    public void StartSpeed()
    {
        Speed = distance / time;
        ActualTime = 0;
        IsStart = true;
    }
}