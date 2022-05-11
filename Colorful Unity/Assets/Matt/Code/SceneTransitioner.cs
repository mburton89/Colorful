using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneTransitioner : MonoBehaviour
{
    //[SerializeField] int sceneToLoad;
    [SerializeField] int secondsToWait = 1;
    [SerializeField] Image fadeImage;

    private void Start()
    {
        fadeImage.DOFade(1, 0);
        fadeImage.DOFade(0, secondsToWait);
    }

    void OnTriggerEnter(Collider other)
    {
        GoToNexLevel();
        if (other.GetComponent<MenteBacata.ScivoloCharacterControllerDemo.SimpleCharacterController>())
        {
            GoToNexLevel();
            other.GetComponent<MenteBacata.ScivoloCharacterControllerDemo.SimpleCharacterController>().gravity = 0;
        }
    }

    private void GoToNexLevel()
    {
        StartCoroutine(GoToNexLevelCo());
    }

    private IEnumerator GoToNexLevelCo()
    {
        fadeImage.DOFade(1, secondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
