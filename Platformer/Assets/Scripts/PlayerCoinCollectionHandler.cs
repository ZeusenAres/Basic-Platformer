using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinCollectionHandler : MonoBehaviour
{

    private Int16 weightInCoins = 0;
    public static PlayerCoinCollectionHandler playerCoinCollectionHandler;

    private void Awake()
    {

        playerCoinCollectionHandler = this;
    }

    public void addWeight(Int16 weight)
    {

        weightInCoins += weight;
    }

    public float getWeight()
    {

        return weightInCoins;
    }
}