using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsContainer;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void CreditsButton()
    {
        // Show Credits Menu
        //MainMenu.SetActive(false);
        CreditsContainer.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        //MainMenu.SetActive(true);
        CreditsContainer.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}