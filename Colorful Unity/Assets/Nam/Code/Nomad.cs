using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nomad : MonoBehaviour
{
    public static Nomad Instance;

    public GameObject axe;
    public GameObject berry1;
    public GameObject berry2;
    public GameObject berry3;
    public bool canBreakDoor;
    

    public Animator animator;

    public AudioSource axeSwingSound;

    public Transform hand;
    public Holdable currentHoldable;

    void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwingAxe();
        }
    }

    void SwingAxe()
    {
        if (axe.activeInHierarchy)
        {
            animator.Play("Axe Swing");
            axeSwingSound.Play();
            if (canBreakDoor && axe.activeInHierarchy)
            {
                FindObjectOfType<Door>().Open();
            }
        }
    }

    public void PickupHoldable(Holdable objectToHold)
    {
        if (currentHoldable == null)
        {
            currentHoldable = objectToHold;

            if (objectToHold.GetComponent<Rigidbody>())
            {
                objectToHold.GetComponent<Rigidbody>().isKinematic = true;
            }

            objectToHold.transform.SetParent(hand);
            objectToHold.transform.localPosition = hand.localPosition;
        }
    }

    public void GiveHoldable()
    {
        if (currentHoldable != null)
        {
            Destroy(currentHoldable.gameObject);
            currentHoldable = null;
        }
    }
}
