using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RedcomApi : MonoBehaviour
{

    private API api;
    private ErrorMessageUI errorMessage;

    void Awake()
    {
        
        api = GetComponent<API>();
        errorMessage = GetComponent<ErrorMessageUI>();
    }

    public IEnumerator registerUser(string username, string password, string email)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        form.AddField("email", email);

        if(api == null)
        {

            errorMessage.setErrorMessage("URL unreachable");

            yield return errorMessage;
        }

        string uri = api.getBaseUrl() + "" + api.getRegisterEndpoint();

        using UnityWebRequest www = UnityWebRequest.Post(uri, form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            errorMessage.setErrorMessage(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
}
