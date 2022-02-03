using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //public AudioSource audioSource;
    private void OnColliderEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            //audioSource.Play();
            print("Fire!");
        }
    }
}

