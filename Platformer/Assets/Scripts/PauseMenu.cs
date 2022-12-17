using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;

    private bool isPaused;

    void Start()
    {
        
        pauseMenu.SetActive(false);
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPaused)
            {

                pauseGame();
            }

            if (!isPaused)
            {

                resumeGame();
            }
        }        
    }

    private void pauseGame()
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    private void resumeGame()
    {
        
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
