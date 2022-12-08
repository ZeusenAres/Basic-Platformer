using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Register : MonoBehaviour
{
    [SerializeField] InputField username;
    [SerializeField] InputField password;
    [SerializeField] InputField repeatedPassword;
    [SerializeField] InputField email;
    [SerializeField] Button register;
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

    public void registerUser()
    {

        string password = this.password.text;

        string repeatedPassword = this.repeatedPassword.text;

        if (!password.Equals(repeatedPassword))
        {

            uiMessage.setErrorMessage("Passwords must match");
        }

        if(password.Equals(repeatedPassword))
        {

            StartCoroutine(redcomApi.registerUser(username.text, password, email.text));
        }
    }

    public void back()
    {

        menuStateHandler.backButton();
    }
}
