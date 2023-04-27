using System;
using System.Collections;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class RedcomApi : MonoBehaviour
{

    private UIMessage uiMessage;
    private UserDTO userDto;
    private MenuStateHandler menuStateHandler;
    [SerializeField] GameObject userData;
    private UserData userDataObject;

    void Start()
    {

        uiMessage = GetComponent<UIMessage>();
        userDto = GetComponent<UserDTO>();
        menuStateHandler = GetComponent<MenuStateHandler>();
        userDataObject = userData.GetComponent<UserData>();
    }

    public IEnumerator registerUser(string usernameInput, string passwordInput, string emailInput)
    {

        userDto.username = usernameInput;
        userDto.password = passwordInput;
        userDto.email = emailInput;

        var postBody = JsonUtility.ToJson(userDto, true);

        string uri = API.getBaseUrl() + API.getRegisterEndpoint();

        using UnityWebRequest www = new UnityWebRequest(uri, "POST");

        byte[] rawPostData = Encoding.UTF8.GetBytes(postBody);

        www.uploadHandler = new UploadHandlerRaw(rawPostData);

        www.downloadHandler = new DownloadHandlerBuffer();

        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Accept", "application/json");

        yield return www.SendWebRequest();
        if(www.result == UnityWebRequest.Result.InProgress)
        {

            StartCoroutine(registerUser(usernameInput, passwordInput, emailInput));
        }

        if (www.result != UnityWebRequest.Result.Success)
        {

            uiMessage.setErrorMessage(www.error);
        }
        else
        {

            menuStateHandler.hrefMenu("Login Menu");

            uiMessage.setErrorMessage("");
        }
    }

    public IEnumerator loginUser(string usernameInput, string passwordInput)
    {

        userDto.username = usernameInput;
        userDto.password = passwordInput;

        var postBody = JsonUtility.ToJson(userDto, true);

        string uri = API.getBaseUrl() + API.getLoginEndpoint();

        using UnityWebRequest www = new UnityWebRequest(uri, "POST");

        byte[] rawPostData = Encoding.UTF8.GetBytes(postBody);

        www.uploadHandler = new UploadHandlerRaw(rawPostData);

        www.downloadHandler = new DownloadHandlerBuffer();

        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Accept", "application/json");

        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.InProgress)
        {

            StartCoroutine(loginUser(usernameInput, passwordInput));
        }

        if (www.result != UnityWebRequest.Result.Success)
        {

            uiMessage.setErrorMessage(www.error);
        }
        else
        {

            menuStateHandler.hrefMenu("Main Menu");
            User user = JsonUtility.FromJson<User>(www.downloadHandler.text);
            userDataObject.username = user.username;
            userDataObject.email = user.email;
            uiMessage.setErrorMessage("");
        }
    }
}

public class User
{
    public string username;
    public string password;
    public string email;
    public short id;
}
