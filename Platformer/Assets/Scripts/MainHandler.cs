using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainHandler : MonoBehaviour
{

    private Player player;
    private string jsonFile = "Assets/Scripts/JSON/Items.json";

    void Start()
    {

        string json = File.ReadAllText(jsonFile);
        Debug.Log(player = JsonUtility.FromJson<Player>(json));
        Time.timeScale = 1.0f;
    }
}
