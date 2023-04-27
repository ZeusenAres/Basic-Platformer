using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] Button login;
    [SerializeField] Button backButton;
    private RedcomApi redcomApi;
    private UIMessage uiMessage;
    private MenuStateHandler menuStateHandler;

    void Awake()
    {
        
        backButton = GetComponent<Button>();
        menuStateHandler = GetComponent<MenuStateHandler>();
        redcomApi = GetComponent<RedcomApi>();
        uiMessage = GetComponent<UIMessage>();
    }

    public void loginUser()
    {

        StartCoroutine(redcomApi.loginUser(username.text, password.text));
    }

    public void back()
    {

        menuStateHandler.backButton();
    }
}
