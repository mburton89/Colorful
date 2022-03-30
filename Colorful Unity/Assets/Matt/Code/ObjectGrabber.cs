using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabber : MonoBehaviour
{
    private GrabbableObject _potentialObject;
    private GrabbableObject _grabbedObject;
    [SerializeField] float throwForce;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_grabbedObject == null)
            {
                if (_potentialObject != null)
                {
                    _grabbedObject = _potentialObject;
                    _grabbedObject.Grab(this);
                }
            }
            else
            {
                if (_grabbedObject != null)
                {
                    _grabbedObject.Fling(throwForce);
                }
                Reset();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<GrabbableObject>())
        {
            _potentialObject = other.GetComponent<GrabbableObject>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<GrabbableObject>() == _potentialObject)
        {
            _potentialObject = null;
        }
    }

    public void Reset()
    {
        _potentialObject = null;
        _grabbedObject = null;
    }
}
