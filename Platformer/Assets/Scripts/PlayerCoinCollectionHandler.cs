using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinCollectionHandler : MonoBehaviour
{

    private float weightInCoins = 0;
    public static PlayerCoinCollectionHandler playerCoinCollectionHandler;

    private void Awake()
    {

        playerCoinCollectionHandler = this;
    }

    public void addWeight(float weight)
    {

        weightInCoins += weight;
    }

    public float getWeight()
    {

        return weightInCoins;
    }
}
