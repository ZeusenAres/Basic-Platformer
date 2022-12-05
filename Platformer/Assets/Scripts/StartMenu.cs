using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    [SerializeField] Button playButton;
    [SerializeField] Button optionsButton;
    [SerializeField] Button quitGameButton;

    void Awake()
    {

        playButton = GetComponent<Button>();
        optionsButton = GetComponent<Button>();
        quitGameButton = GetComponent<Button>();
    }

    public void playGame()
    {

        SceneManager.LoadScene("Level 1");
    }

    public void settings()
    {

        
    }

    public void quit()
    {

        Application.Quit();
    }

}
