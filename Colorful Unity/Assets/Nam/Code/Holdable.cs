using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    public bool isWinningBerry;
    bool canBeHeld;

    private void Start()
    {
        canBeHeld = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        if (other.GetComponent<Nomad>() && canBeHeld)
        {
            canBeHeld = false;
            other.GetComponent<Nomad>().PickupHoldable(this);
        }
    }
}
