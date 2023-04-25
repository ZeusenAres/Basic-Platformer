using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;

[System.Serializable]
public class Position
{

    public float x;
    public float y;
}

public class SavedDataDeserializer : MonoBehaviour
{

    [SerializeField] TextAsset jsonPosition;
    private Position position;
    void Start()
    {
        
        position = JsonUtility.FromJson<Position>(jsonPosition.text);
    }

    public Position getSavedPositions()
    {

        return position;
    }
}
