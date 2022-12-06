using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Register : MonoBehaviour
{
    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;
    [SerializeField] TMP_InputField repeatedPassword;
    [SerializeField] TMP_InputField email;
    [SerializeField] Button register;
    [SerializeField] Button backButton;

    private RedcomApi redcomApi;
    private ErrorMessageUI errorMessageUI;
    private string error;

    private MenuStateHandler menuStateHandler;

    void Awake()
    {

        backButton = GetComponent<Button>();
        menuStateHandler = GetComponent<MenuStateHandler>();
        redcomApi = GetComponent<RedcomApi>();
        errorMessageUI = GetComponent<ErrorMessageUI>();

        error = errorMessageUI.getErrorMessageUI();
    }

    public void registerUser()
    {

        if (!password.text.Equals(repeatedPassword))
        {

            error = "Passwords must match";
        }

        if(password.text.Equals(repeatedPassword))
        {

            StartCoroutine(redcomApi.registerUser(username.text, password.text, email.text));
        }
    }

    public void back()
    {

        menuStateHandler.backButton();
    }
}
