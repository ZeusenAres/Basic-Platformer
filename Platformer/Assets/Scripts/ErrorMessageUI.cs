using TMPro;
using UnityEngine;

public class ErrorMessageUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI errerMessage;

    public string setErrorMessage(string message)
    {

        return errerMessage.text = message;
    }
}
