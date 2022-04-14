using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public float secondsToOpenDoor;
    public GameObject chain;
    public bool testing;

    private void Update()
    {
        if (testing)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Open();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                Close();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Nomad>().canBreakDoor = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<Nomad>().canBreakDoor = false;
        }
    }

    public void Open()
    {
        StartCoroutine(OpenDoorSequence());
    }

    private IEnumerator OpenDoorSequence()
    {
        chain.SetActive(false);
        Instantiate(Resources.Load("Explosion") as GameObject, chain.transform.position, transform.rotation, null);
        yield return new WaitForSeconds(1f);
        transform.DOLocalRotate(new Vector3(0, 180, 0), secondsToOpenDoor, RotateMode.Fast).SetEase(Ease.OutBounce);
    }

    public void Close()
    {
        transform.DOLocalRotate(new Vector3(0, 0, 0), secondsToOpenDoor, RotateMode.Fast).SetEase(Ease.OutBounce);
    }
}
