using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CoinHandler : MonoBehaviour
{

    private SpriteRenderer coinSprite;
    private readonly Int16 coinAmount = 1;
    [SerializeField] GameObject mainHandler;
    private ItemDeserializer coinDeserializer;
    [SerializeField] GameObject player;
    private PlayerCoinCollectionHandler playerCoinCollectionHandler;
    [SerializeField] GameObject playerUi;
    private CoinScoreHandler coinScoreHandler;
    private bool isDestroyed;

    private void Awake()
    {

        coinDeserializer = mainHandler.GetComponent<ItemDeserializer>();
        coinSprite = GetComponent<SpriteRenderer>();
        playerCoinCollectionHandler = player.GetComponent<PlayerCoinCollectionHandler>();
        coinScoreHandler = playerUi.GetComponent<CoinScoreHandler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            if(isDestroyed == true)
            {

                return;
            }

            Destroy(gameObject);

            var coins = coinDeserializer.getCoins();

            foreach (var coin in coinDeserializer.getCoins())
            {

                if (gameObject.CompareTag(coin.tag))
                {

                    string setWeight = coinScoreHandler.setWeight(coin.weight.ToString());

                    coinScoreHandler.updateScoreDisplay(coinAmount, coin.coinValue, coinSprite.sprite, setWeight, coinSprite.color);

                    playerCoinCollectionHandler.addWeight(coin.weight);

                    isDestroyed = true;

                    break;
                }
            }
        }
    }
}
