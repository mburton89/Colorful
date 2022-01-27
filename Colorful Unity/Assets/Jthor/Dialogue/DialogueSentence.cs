using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueSentence
{
    public enum FireWallCharacter
    {
        RedNymph,
        YellowNymph,
        GreenNymph,
        BlueNymph,
        PurpleNymph,
        BlackNymph,
        Nomad
    }

    public FireWallCharacter characterSpeaking;

    [TextArea(3, 10)]
    public string sentence;
}
