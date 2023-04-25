using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Default
{

    public float speed;
    public float jumpForce;
    public float dashTime;
    public float dashCooldown;
    public float dashForce;
}

[System.Serializable]
public class PlayerDefault
{

    public List<Default> defaults;
}

public class PlayerDeserializer : MonoBehaviour
{

    [SerializeField] private TextAsset jsonPlayer;

    public List<Default> getDefaults()
    {

        return JsonUtility.FromJson<PlayerDefault>(jsonPlayer.text).defaults; ;
    }
}
