using TMPro;
using UnityEngine;

public class UIMessage : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI errerMessage;
    [SerializeField] TextMeshProUGUI usernameDisplay;

    public string setErrorMessage(string message)
    {

        return errerMessage.text = message;
    }

    public string setUsernameDisplay(string message)
    {

        return usernameDisplay.text = message;
    }
}
