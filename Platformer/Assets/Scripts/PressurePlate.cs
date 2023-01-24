using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlate : MonoBehaviour
{

    [SerializeField] float targetWeight;
    private readonly PlayerCoinCollectionHandler playerCoinCollectionHandler;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            if (PlayerCoinCollectionHandler.playerCoinCollectionHandler.getWeight() == targetWeight)
            {

                SceneManager.LoadScene("Start");
            }
        }
    }
}
