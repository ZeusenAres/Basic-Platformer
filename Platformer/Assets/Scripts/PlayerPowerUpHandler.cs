using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpHandler : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerMovement playerMovement;
    private float defaultSpeed;
    private float defaultJumpForce;

    private void Awake()
    {

        playerMovement = player.GetComponent<PlayerMovement>();
        defaultSpeed = playerMovement.getSpeed();
        defaultJumpForce = playerMovement.getJumpForce();
    }

    public IEnumerator setPowerUpDuration(int seconds, GameObject gameObject)
    {

        yield return new WaitForSeconds(seconds);
        playerMovement.setSpeed(defaultSpeed);
        playerMovement.setJumpForce(defaultJumpForce);
        Destroy(gameObject);
    }
}
