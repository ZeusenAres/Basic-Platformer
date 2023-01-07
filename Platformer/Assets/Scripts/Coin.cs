using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private readonly int coinAmount = 1;
    private int coinValue;
    private float weight;

    private void Awake()
    {

        if (gameObject.CompareTag("Regular Coin"))
        {

            weight = 12.5f;

            coinValue = 1;
        }

        if (gameObject.CompareTag("Special Coin"))
        {

            weight = 24.5f;

            coinValue = 5;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {

            CoinScoreHandler.coinScoreHandler.updateScoreDisplay(coinAmount, coinValue);

            PlayerCoinCollectionHandler.playerCoinCollectionHandler.addWeight(weight);

            Destroy(gameObject);
        }
    }
}
