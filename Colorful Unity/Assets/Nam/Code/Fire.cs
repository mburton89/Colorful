using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioSource.Play();
            print("Fire!");
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine("FlashColor");
            print("Change Color");
        }
    }

    IEnumerator FlashColor()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(0.5f);
        print("Bruh");
    }
}

