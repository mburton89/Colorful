using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GrabbableObject : MonoBehaviour
{
    public AudioSource pickUpSound;
    private Rigidbody _rb;
    private ObjectGrabber _controller;

    private Vector3 _previousPosition;
    private Vector3 _currentPosition;

    [SerializeField] GameObject objectToSpawn;

    bool hasBeenFlung;

    public enum Type
    {
        barrel,
        axe
    }

    private void Update()
    {
        _previousPosition = _currentPosition;
        _currentPosition = transform.position;
    }

    public void Grab(ObjectGrabber controller)
    {
        _controller = controller;
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        transform.SetParent(_controller.transform);
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
    }

    public void LetGo()
    {
        if (_controller != null)
        {
            _controller.Reset();
        }
        _rb.isKinematic = false;
        _rb.transform.SetParent(null);
    }

    public void Fling(float throwForce)
    {
        LetGo();
        _rb.AddForce((_controller.transform.forward + Vector3.up * 2) * throwForce);
        hasBeenFlung = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasBeenFlung && (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Wall"))
        {
            Instantiate(Resources.Load("Explosion") as GameObject, transform.position, transform.rotation, null);
            //TODO make sound
            //spawn whatever object its holding (ie Axe)
            if (objectToSpawn != null)
            {
                Instantiate(objectToSpawn, transform.position, transform.rotation, null);
            }

            Destroy(gameObject);
        }
    }
}
