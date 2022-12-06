using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RedcomApi : MonoBehaviour
{

    private API api;
    private ErrorMessageUI errorMessageUI;
    private string errorMessage;

    void Awake()
    {
        
        api = GetComponent<API>();
        errorMessageUI = GetComponent<ErrorMessageUI>();

        errorMessage = errorMessageUI.getErrorMessageUI();
    }

    public IEnumerator registerUser(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        form.AddField("email", email);

        using (UnityWebRequest www = UnityWebRequest.Post(api.baseUrl + api.registerEndpoint, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                errorMessage = www.error;
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}
