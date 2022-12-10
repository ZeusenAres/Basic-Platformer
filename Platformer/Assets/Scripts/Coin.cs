using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private int coinValue = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Player"))
        {

            CoinScoreHandler.coinScoreHandler.updateScoreDisplay(coinValue);

            Destroy(gameObject);
        }
    }
}
