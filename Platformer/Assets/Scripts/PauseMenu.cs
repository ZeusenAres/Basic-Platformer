using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] Button resumeButton;
    [SerializeField] Button GameSettingsButton;
    [SerializeField] Button startMenuButton;

    private bool isPaused;

    void Start()
    {
        
        pauseMenu.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            switch(isPaused)
            {
                case true:
                    pauseGame();
                    break;

                case false:
                    resumeGame();
                    break;
            }
        }        
    }

    private void pauseGame()
    {

        pauseMenu.SetActive(true);

        Time.timeScale = 0;

        isPaused = false;
    }

    public void resumeGame()
    {

        pauseMenu.SetActive(false);

        Time.timeScale = 1;

        isPaused = true;
    }

    public void gameSettings()
    {

        Debug.Log("Coming Soon...");
    }

    public void startMenu()
    {

        SceneManager.LoadScene("Start");
    }
}
