using System;
using System.Collections;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class RedcomApi : MonoBehaviour
{

    private ErrorMessageUI errorMessage;

    private UserDTO userDto;

    void Awake()
    {

        errorMessage = GetComponent<ErrorMessageUI>();
        userDto = GetComponent<UserDTO>();
    }

    public IEnumerator registerUser(string usernameInput, string passwordInput, string emailInput)
    {

        userDto.username = usernameInput;
        userDto.password = passwordInput;
        userDto.email = emailInput;

        string backslash = @"\";

        var postBody = JsonUtility.ToJson(userDto, true).Replace(backslash, "");

        string doubleQuote = "\u0022";

        doubleQuote.Substring(0, 1);

        postBody = postBody.Replace("\"", doubleQuote);

        postBody = postBody.Replace(":", ": ");

        string uri = API.getBaseUrl() + API.getRegisterEndpoint();

        using UnityWebRequest www = UnityWebRequest.Post(uri, postBody);

        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Accept", "application/json");

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            errorMessage.setErrorMessage(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
}
