using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    [SerializeField] Button backButton;

    private MenuStateHandler menuStateHandler;

    void Awake()
    {

        backButton = GetComponent<Button>();
        menuStateHandler = GetComponent<MenuStateHandler>();
    }

    public void back()
    {

        menuStateHandler.backButton();
    }
}
