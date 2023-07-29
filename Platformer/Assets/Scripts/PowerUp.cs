using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerMovement playerMovement;
    private PlayerPowerUpHandler playerPowerUpHandler;
    [SerializeField] SpriteRenderer powerUpSprite;
    [SerializeField] GameObject mainHandler;
    private ItemDeserializer itemDeserializer;
    [SerializeField] GameObject self;
    private BoxCollider2D boxCollider2D;
    private bool isActivated = false;

    private void Awake()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerPowerUpHandler = player.GetComponent<PlayerPowerUpHandler>();
        itemDeserializer = mainHandler.GetComponent<ItemDeserializer>();
        boxCollider2D = self.GetComponent<BoxCollider2D>();
    }

    private object setterInvoke(PowerUpClass list, object getter)
    {

        isActivated = true;
        
        var method = playerMovement.GetType().GetMethod(
                        list.setter,
                        BindingFlags.Public | BindingFlags.Instance,
                        null,
                        CallingConventions.Any,
                        new Type[] { typeof(float) },
                        null
                    );

        float setValue = (float)getter * list.multiplier;

        return method.Invoke(playerMovement, new object[] { setValue });
    }

    private object getterInvoke(PowerUpClass list)
    {

        var method = playerMovement.GetType().GetMethod(
                        list.getter,
                        BindingFlags.Public | BindingFlags.Instance,
                        null,
                        CallingConventions.Any,
                        new Type[] { },
                        null
                    );

        return method.Invoke(playerMovement, new object[] {  });
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {

            foreach (var powerUp in itemDeserializer.getPowerUps())
            {

                if (isActivated == true)
                {

                    break;
                }

                if (gameObject.CompareTag(powerUp.tag))
                {

                    setterInvoke(powerUp, getterInvoke(powerUp));
                }

                powerUpSprite.sprite = null;
                gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform, false);
                StartCoroutine(playerPowerUpHandler.setPowerUpDuration(powerUp.duration, gameObject));
                boxCollider2D.enabled = false;
                break;
            }
        }

        isActivated = false;
    }
}
