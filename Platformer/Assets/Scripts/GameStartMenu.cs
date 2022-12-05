using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameStartMenu : MonoBehaviour
{

    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject settingsMenu;

    [SerializeField] Button playButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button quitGameButton;
    [SerializeField] Button backButton;

    void Awake()
    {

        playButton = GetComponent<Button>();
        optionsButton = GetComponent<Button>();
        quitGameButton = GetComponent<Button>();
        backButton = GetComponent<Button>();

        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void playGame()
    {

        SceneManager.LoadScene("Level 1");
    }

    public void settings()
    {

        startMenu.SetActive(false);

        settingsMenu.SetActive(true);
    }

    public void back()
    {

        startMenu.SetActive(true);

        settingsMenu.SetActive(false);
    }

    public void quit()
    {

        Application.Quit();
    }
}
