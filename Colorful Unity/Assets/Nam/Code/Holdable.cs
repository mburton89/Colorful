using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    bool canBeHeld = true;
    public bool isWinningBerry;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Nomad>() && canBeHeld)
        {
            canBeHeld = false;
            other.GetComponent<Nomad>().PickupHoldable(this);
        }
    }
}
