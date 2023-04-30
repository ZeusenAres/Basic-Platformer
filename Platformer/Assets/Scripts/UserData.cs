using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData instance;
    public string username;
    public string email;
    [SerializeField] TextMeshProUGUI usernameDisplay;

    void Awake()
    {

        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }

        if(usernameDisplay != null)
        {

            usernameDisplay.text = username;
        }
    }
}
