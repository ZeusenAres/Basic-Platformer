using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameStartMenu : MonoBehaviour
{

    private MenuStateHandler menuStateHandler;

    private StartMenu startMenu;

    void Awake()
    {

        menuStateHandler = GetComponent<MenuStateHandler>();
        startMenu = GetComponent<StartMenu>();

        menuStateHandler.hrefMenu("Main Menu");
    }
}
