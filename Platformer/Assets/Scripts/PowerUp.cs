using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerMovement playerMovement;
    private PlayerPowerUpHandler playerPowerUpHandler;
    [SerializeField] SpriteRenderer powerUpSprite;
    [SerializeField] int duration;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerPowerUpHandler = player.GetComponent<PlayerPowerUpHandler>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (gameObject.CompareTag("AddSpeed"))
            {

                playerMovement.setSpeed(playerMovement.getSpeed() * 2);
            }

            if (gameObject.CompareTag("AddJump"))
            {

                playerMovement.setJumpForce(playerMovement.getJumpForce() * 2);
            }
            powerUpSprite.sprite = null;
            gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform, false);
            StartCoroutine(playerPowerUpHandler.setPowerUpDuration(duration, gameObject));
        }
    }
}
