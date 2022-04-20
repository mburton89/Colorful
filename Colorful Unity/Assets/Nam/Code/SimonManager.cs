using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.SceneManagement;

public class SimonManager : MonoBehaviour
{
    public GameObject gameButtonPrefab;

    public List<ButtonSetting> buttonSettings;

    public Transform gameFieldPanelTransform;

    List<GameObject> gameButtons;
    private System.Random randomNumberGen;
    int bleepCount = 2;

    List<int> bleeps;
    List<int> playerBleeps;

    System.Random rg;

    bool inputEnabled = false;
    bool gameOver = false;

    [SerializeField] GameObject container;

    [SerializeField] List<LightMovement> stageLights;

    [SerializeField] ParticleSystem redParticles;
    [SerializeField] ParticleSystem yellowParticles;
    [SerializeField] ParticleSystem greenParticles;
    [SerializeField] ParticleSystem blueParticles;

    bool isPlayersTurn;

    public void Reset()
    {
        print("Reset");
        bleepCount = 2;
    }

    public void StartSimonSays()
    {
        container.SetActive(true);

        gameButtons = new List<GameObject>();

        randomNumberGen = new System.Random(DateTime.Now.Millisecond);

        CreateGameButton(0, new Vector3(-64, 64));
        CreateGameButton(1, new Vector3(64, 64));
        CreateGameButton(2, new Vector3(-64, -64));
        CreateGameButton(3, new Vector3(64, -64));


        StartCoroutine(SimonSays());
    }

    void CreateGameButton(int index, Vector3 position)
    {
        GameObject gameButton = Instantiate(gameButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        gameButton.transform.SetParent(gameFieldPanelTransform);
        gameButton.transform.localPosition = position;

        gameButton.GetComponent<Image>().color = buttonSettings[index].normalColor;
        gameButton.GetComponent<Button>().onClick.AddListener(() => {
            OnGameButtonClick(index);
        });

        gameButtons.Add(gameButton);
    }

    void PlayAudio(int index)
    {
        float length = 0.5f;
        float frequency = 0.001f * ((float)index + 1f);

        AnimationCurve volumeCurve = new AnimationCurve(new Keyframe(0f, 1f, 0f, -1f), new Keyframe(length, 0f, -1f, 0f));
        AnimationCurve frequencyCurve = new AnimationCurve(new Keyframe(0f, frequency, 0f, 0f), new Keyframe(length, frequency, 0f, 0f));

        LeanAudioOptions audioOptions = LeanAudio.options();
        audioOptions.setWaveSine();
        audioOptions.setFrequency(44100);

        AudioClip audioClip = LeanAudio.createAudio(volumeCurve, frequencyCurve, audioOptions);

        LeanAudio.play(audioClip, 0.5f);
    }

    void OnGameButtonClick(int index)
    {
        if (!inputEnabled)
        {
            return;
        }

        Bleep(index);

        playerBleeps.Add(index);

        if (bleeps[playerBleeps.Count - 1] != index)
        {
            GameOver();
            return;
        }

        if (bleeps.Count == playerBleeps.Count)
        {
            StartCoroutine(SimonSays());
        }
    }

    void GameOver()
    {
        gameOver = true;
        inputEnabled = false;
    }

    IEnumerator SimonSays()
    {
        isPlayersTurn = false;

        foreach (LightMovement stageLight in stageLights)
        {
            stageLight.MoveToPosition1();
        }

        if (bleepCount == 6)
        {
            FindObjectOfType<Door>().Open();
            Destroy(gameObject);
        }

        inputEnabled = false;

        var randomNumber = randomNumberGen;
        rg = new System.Random(randomNumber.GetHashCode());

        SetBleeps();

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < bleeps.Count; i++)
        {
            Bleep(bleeps[i]);

            yield return new WaitForSeconds(0.6f);
        }

        foreach (LightMovement stageLight in stageLights)
        {
            stageLight.MoveToPosition2();
        }

        inputEnabled = true;

        isPlayersTurn = false;

        yield return null;
    }

    void Bleep(int index)
    {
        LeanTween.value(gameButtons[index], buttonSettings[index].normalColor, buttonSettings[index].highlightColor, 0.25f).setOnUpdate((Color color) => {
            gameButtons[index].GetComponent<Image>().color = color;
        });

        if (!inputEnabled)
        {
            EmitColoredNote(index);
        }

        LeanTween.value(gameButtons[index], buttonSettings[index].highlightColor, buttonSettings[index].normalColor, 0.25f)
            .setDelay(0.5f)
            .setOnUpdate((Color color) => {
                gameButtons[index].GetComponent<Image>().color = color;
            });

        PlayAudio(index);
    }

    void EmitColoredNote(int index)
    {
        if (index == 0)
        {
            redParticles.Emit(1);
        }
        else if (index == 1)
        {
            yellowParticles.Emit(1);
        }
        else if (index == 2)
        {
            greenParticles.Emit(1);
        }
        else if (index == 3)
        {
            blueParticles.Emit(1);
        }
    }

    void SetBleeps()
    {
        bleeps = new List<int>();
        playerBleeps = new List<int>();

        for (int i = 0; i < bleepCount; i++)
        {
            bleeps.Add(rg.Next(0, gameButtons.Count));
        }

        bleepCount++;
    }
}