using UnityEngine;

public class API : MonoBehaviour
{
    private string baseUrl = "localhost:9085";

    private string registerEndpoint = "/register";

    public string getBaseUrl()
    {

        return baseUrl;
    }

    public string getRegisterEndpoint()
    {

        return registerEndpoint;
    }
}
