using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRoomManager : MonoBehaviour
{

    public static GreenRoomManager Instance;
    // Start is called before the first frame update

    [SerializeField] string intro_sentence;
    [SerializeField] string wrong_berry_sentence;
    [SerializeField] string right_berry_sentence;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        DialogueManager.Instance.DisplaySentence(DialogueSentence.FireWallCharacter.GreenNymph, intro_sentence);
    }

    public void HandleWrongBerry()
    {
        DialogueManager.Instance.DisplaySentence(DialogueSentence.FireWallCharacter.GreenNymph, wrong_berry_sentence);
    }

    public void HandleRightBerry()
    {
        DialogueManager.Instance.DisplaySentence(DialogueSentence.FireWallCharacter.GreenNymph, right_berry_sentence);
    }
}
