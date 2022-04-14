using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour, IInteractable 
{
    public DialogueTrigger dialoguetrigger;
    Material mat;

    public void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    public string GetDescription()
    {
        return "Get a hint";

    }

    public void Interact()
    {
        dialoguetrigger.TriggerDialogue();
    }
}
