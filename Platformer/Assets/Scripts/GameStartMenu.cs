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
}
