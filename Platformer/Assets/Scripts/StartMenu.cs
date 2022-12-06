using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    [SerializeField] Button playButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button quitGameButton;
    [SerializeField] Button registerButton;
    [SerializeField] Button loginButton;

    private MenuStateHandler menuStateHandler;

    void Awake()
    {

        playButton = GetComponent<Button>();
        optionsButton = GetComponent<Button>();
        quitGameButton = GetComponent<Button>();
        registerButton = GetComponent<Button>();
        loginButton = GetComponent<Button>();
        menuStateHandler = GetComponent<MenuStateHandler>();
    }

    public void playGame()
    {

        SceneManager.LoadScene("Level 1");
    }

    public void options()
    {

        menuStateHandler.hrefMenu("Options Menu");
    }

    public void quit()
    {

        Application.Quit();
    }

    public void register()
    {

        menuStateHandler.hrefMenu("Register Menu");
    }

    public void login()
    {

        menuStateHandler.hrefMenu("Login Menu");
    }
}
