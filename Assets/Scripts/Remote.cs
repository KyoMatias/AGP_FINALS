using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour
{
    public GameObject car;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Placeable")
        {
            car.GetComponent<MoveToyCar>().StartSpeed();
        }
    }
}
