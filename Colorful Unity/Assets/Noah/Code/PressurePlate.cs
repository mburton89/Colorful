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

    SimonManager simonManager;

    [SerializeField] GameObject dialogueBox;
    bool hasSeenDialogue;
    bool hasStartedSimonSays;

    void Start()
    {
        simonManager = FindObjectOfType<SimonManager>();
        initialYPosition = transform.position.y;
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(transform.position.x, initialYPosition - distanceToMove, transform.position.z);
        
        meshRenderer.material = lit;
        simonManager.LightUpNymph();
        StartCoroutine(ShowDialogue());
    }

    private void OnTriggerExit(Collider other)
    {
        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
        simonSaysHud.SetActive(false);
        hasStartedSimonSays = false;
        meshRenderer.material = unlit;
        simonManager.Reset();
    }

    private IEnumerator ShowDialogue()
    {
        if (!hasSeenDialogue)
        {
            dialogueBox.SetActive(true);
            yield return new WaitForSeconds(4);
        }
        else
        {
            yield return new WaitForSeconds(0);
        }
        hasSeenDialogue = true;

        if (!hasStartedSimonSays)
        {
            dialogueBox.SetActive(false);
            simonSaysHud.SetActive(true);
            simonManager.StartSimonSays();
            hasStartedSimonSays = true;
        }
    }
}
