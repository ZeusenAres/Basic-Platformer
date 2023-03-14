using UnityEngine;

public class API : MonoBehaviour
{

    private API api;
    private static string baseUrl = "localhost:9085";
    private static string registerEndpoint = "/register";
    private static string loginEndpoint = "/login";

    private void Awake()
    {

        api = this;
    }

    public static string getBaseUrl()
    {

        return baseUrl;
    }

    public static string getRegisterEndpoint()
    {

        return registerEndpoint;
    }

    public static string getLoginEndpoint()
    {

        return loginEndpoint;
    }
}
