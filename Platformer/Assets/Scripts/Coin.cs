using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private SpriteRenderer coinSprite;
    private readonly Int16 coinAmount = 1;
    private Int16 coinValue;
    private Int16 weight;
    private new string tag;

    private void Awake()
    {

        coinSprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {

            if (gameObject.CompareTag("Regular Coin"))
            {

                tag = "regular";
            }

            if (gameObject.CompareTag("Special Coin"))
            {

                tag = "special";
            }

            switch (tag)
            {
                case "regular":
                    weight = 12;
                    coinValue = 1;
                    break;

                case "special":
                    weight = 24;
                    coinValue = 5;
                    break;
            }

            CoinScoreHandler.coinScoreHandler.updateScoreDisplay(coinAmount, coinValue);

            CoinScoreHandler.coinScoreHandler.addToCoinDisplay(coinSprite.sprite, weight, coinSprite.color);

            PlayerCoinCollectionHandler.playerCoinCollectionHandler.addWeight(weight);

            weight = 0;

            coinValue = 0;

            Destroy(gameObject);
        }
    }
}
