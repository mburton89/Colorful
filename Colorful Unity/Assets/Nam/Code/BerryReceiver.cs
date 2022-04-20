using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryReceiver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Nomad>())
        {
            if (other.gameObject.GetComponent<Nomad>().currentHoldable != null)
            {
                if (other.gameObject.GetComponent<Nomad>().currentHoldable.isWinningBerry)
                {
                    print("Winner");
                }
                else
                {
                    print("Wrong Berry!");
                    other.gameObject.GetComponent<Nomad>().GiveHoldable();
                }
            }
        }
    }
}
