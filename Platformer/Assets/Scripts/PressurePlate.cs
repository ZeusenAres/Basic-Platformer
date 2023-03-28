using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlate : MonoBehaviour
{

    [SerializeField] float targetWeight;
    [SerializeField] GameObject player;
    private PlayerCoinCollectionHandler playerCoinCollectionHandler;

    private void Awake()
    {

        playerCoinCollectionHandler = player.GetComponent<PlayerCoinCollectionHandler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            if (playerCoinCollectionHandler.getWeight() == targetWeight)
            {

                SceneManager.LoadScene("Start");
            }
        }
    }
}
