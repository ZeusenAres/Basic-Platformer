using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private SpriteRenderer coinSprite;
    private readonly int coinAmount = 1;
    private int coinValue;
    private Int16 weight;

    private void Awake()
    {

        coinSprite = GetComponent<SpriteRenderer>();

        if (gameObject.CompareTag("Regular Coin"))
        {

            weight = 12;

            coinValue = 1;
        }

        if (gameObject.CompareTag("Special Coin"))
        {

            weight = 24;

            coinValue = 5;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {

            CoinScoreHandler.coinScoreHandler.updateScoreDisplay(coinAmount, coinValue);

            CoinScoreHandler.coinScoreHandler.addToCoinDisplay(coinSprite.sprite, weight, coinSprite.color);

            PlayerCoinCollectionHandler.playerCoinCollectionHandler.addWeight(weight);

            Destroy(gameObject);
        }
    }
}
