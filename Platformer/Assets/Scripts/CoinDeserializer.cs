using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;

public class CoinDeserializer : MonoBehaviour
{

    [SerializeField] private TextAsset jsonCoins;
    private Collectables coinList;

    void Start()
    {

        coinList = JsonUtility.FromJson<Collectables>(jsonCoins.text);
    }

    public List GetCoinClasses()
    {

        return coinList;
    }
}

[System.Serializable]
public class CoinClass
{

    public string tag;
    public Int16 weight;
    public Int16 coinValue;
}

[System.Serializable]
public class Collectables
{

    public List<CoinClass> collectableCoins;
}
