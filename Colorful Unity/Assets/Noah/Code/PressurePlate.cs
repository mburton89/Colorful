using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PressurePlate : MonoBehaviour
{
    float initialYPosition;
    [SerializeField] float distanceToMove;
    [SerializeField] private GameObject simonSaysHud;
    [SerializeField] ParticleSystem particleSystem;
    public Color simonColor;

    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Material unlit;
    [SerializeField] Material lit;

    void Start()
    {
        initialYPosition = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, initialYPosition - distanceToMove, transform.position.z);
        simonSaysHud.SetActive(true);
        particleSystem.startColor = simonColor;
        particleSystem.Play();
        meshRenderer.material = lit; 
        FindObjectOfType<DialogueTrigger>().TriggerDialogue();
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
        simonSaysHud.SetActive(false);
        particleSystem.Stop();
        meshRenderer.material = unlit;
    }
}
