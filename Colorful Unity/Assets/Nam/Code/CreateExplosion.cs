using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateExplosion : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadius;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("hi");
        Explode();
    }

    void Explode()
    {
        rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
    } 
}
