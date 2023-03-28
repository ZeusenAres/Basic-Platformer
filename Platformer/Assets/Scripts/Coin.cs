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
    [SerializeField] GameObject player;
    private PlayerCoinCollectionHandler playerCoinCollectionHandler;
    [SerializeField] GameObject playerUi;
    private CoinScoreHandler coinScoreHandler;

    private void Awake()
    {

        coinSprite = GetComponent<SpriteRenderer>();
        playerCoinCollectionHandler = player.GetComponent<PlayerCoinCollectionHandler>();
        coinScoreHandler = playerUi.GetComponent<CoinScoreHandler>();
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

            string setWeight = coinScoreHandler.setWeight(weight.ToString());

            coinScoreHandler.updateScoreDisplay(coinAmount, coinValue, coinSprite.sprite, setWeight, coinSprite.color);

            playerCoinCollectionHandler.addWeight(weight);

            weight = 0;

            coinValue = 0;

            Destroy(gameObject);
        }
    }
}
