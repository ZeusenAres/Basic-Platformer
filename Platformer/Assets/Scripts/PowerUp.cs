using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerMovement playerMovement;
    [SerializeField] SpriteRenderer powerUpSprite;
    [SerializeField] int duration;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (gameObject.CompareTag("AddSpeed"))
            {
                playerMovement.setSpeed(20f);
            }

            if (gameObject.CompareTag("AddJump"))
            {
                playerMovement.setJumpForce(15f);
            }
            powerUpSprite.sprite = null;
            gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform, false);
            StartCoroutine(playerMovement.setPowerUpDuration(duration, gameObject));
        }
    }
}
