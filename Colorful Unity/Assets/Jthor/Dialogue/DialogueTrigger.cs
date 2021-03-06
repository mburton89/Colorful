using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue diaglogue;
    public List<Sprite> portraitSprites;
    [HideInInspector] public bool canTrigger;

    public GameObject pressEBox;

    private void Awake()
    {
        canTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        if (other.tag == "Player" && canTrigger)
        {
            if (pressEBox != null)
            {
                pressEBox.SetActive(true);
            }
            DialogueManager.Instance.canStartConvo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("OnTriggerExit");
        if (other.tag == "Player")
        {
            pressEBox.SetActive(false);
            DialogueManager.Instance.canStartConvo = false;
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager.Instance.StartDialogue(diaglogue, portraitSprites);

        if (pressEBox != null)
        {
            pressEBox.SetActive(false);
        }
    }

    public void EndDialogue()
    {
        DialogueManager.Instance.EndDialogue();
    }
}
