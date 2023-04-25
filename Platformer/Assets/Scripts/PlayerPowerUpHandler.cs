using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpHandler : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject mainHandler;
    private List<Default> defaultProperties;
    private PlayerMovement playerMovement;
    private float defaultSpeed;
    private float defaultJumpForce;

    private void Awake()
    {
        defaultProperties = mainHandler.GetComponent<PlayerDeserializer>().getDefaults();
        playerMovement = player.GetComponent<PlayerMovement>();
        foreach (var defaultProperty in defaultProperties)
        {
            defaultSpeed = defaultProperty.speed;
            defaultJumpForce = defaultProperty.jumpForce;
        }
    }

    public IEnumerator setPowerUpDuration(float seconds, GameObject gameObject)
    {

        yield return new WaitForSeconds(seconds);
        playerMovement.setSpeed(defaultSpeed);
        playerMovement.setJumpForce(defaultJumpForce);
        Destroy(gameObject);
    }
}
