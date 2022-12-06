using TMPro;
using UnityEngine;

public class ErrorMessageUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI errerMessage;

    void Start()
    {
        
        errerMessage = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public string getErrorMessageUI()
    {
        
        return errerMessage.text;
    }
}
