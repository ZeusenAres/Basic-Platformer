using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System;

[System.Serializable]
public class PowerUpClass
{

    public string tag;
    public string getter;
    public string setter;
    public float multiplier;
    public float duration;
}

[System.Serializable]
public class PowerUps
{

    public List<PowerUpClass> powerUps;
}

[System.Serializable]
public class CoinClass
{

    public string tag;
    public Int16 weight;
    public Int16 coinValue;
}

[System.Serializable]
public class Coins
{

    public List<CoinClass> collectableCoins;
}

public class ItemDeserializer : MonoBehaviour
{

    [SerializeField] private TextAsset jsonItems;
    private Coins coinList;
    private PowerUps powerUpList;

    void Start()
    {

        coinList = JsonUtility.FromJson<Coins>(jsonItems.text);
        powerUpList = JsonUtility.FromJson<PowerUps>(jsonItems.text);
    }

    public List<CoinClass> getCoins()
    {

        return coinList.collectableCoins;
    }

    public List<PowerUpClass> getPowerUps()
    {

        return powerUpList.powerUps;
    }
}
