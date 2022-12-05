using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameStartMenu : MonoBehaviour
{

    private MenuStateHandler menuStateHandler;

    void Awake()
    {

        menuStateHandler = GetComponent<MenuStateHandler>();

        menuStateHandler.hrefMenu("Main Menu");
    }

    public void playGame()
    {

        SceneManager.LoadScene("Level 1");
    }

    public void quitGame()
    {

        Application.Quit();
    }

    public void optionsMenu()
    {

        menuStateHandler.hrefMenu("Options Menu");
    }

    public void registerMenu()
    {

        menuStateHandler.hrefMenu("Register Menu");
    }

    public void loginMenu()
    {

        menuStateHandler.hrefMenu("Login Menu");
    }
}
