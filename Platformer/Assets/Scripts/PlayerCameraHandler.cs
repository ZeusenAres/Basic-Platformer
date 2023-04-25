using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraHandler : MonoBehaviour
{

    [SerializeField] CinemachineVirtualCamera playerCam;
    [SerializeField] GameObject player;
    private PlayerMovement playerMovement;
    private float defaultSpeed;
    private float defaultJumpForce;
    private bool isPoweredUp = false;

    private void Start()
    {

        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {

        if (defaultSpeed == 0)
        {

            defaultSpeed = playerMovement.getSpeed();
            defaultJumpForce = playerMovement.getJumpForce();
        }

        if (playerMovement.getSpeed() > defaultSpeed || playerMovement.getJumpForce() > defaultJumpForce)
        {

            expandLens();
        }

        if (playerMovement.getSpeed() == defaultSpeed || playerMovement.getJumpForce() == defaultJumpForce)
        {

            revertLens();
        }
    }

    private float expandLens()
    {

        if(playerCam.m_Lens.OrthographicSize < 7f)
        {

            playerCam.m_Lens.OrthographicSize += 0.05f;
            StartCoroutine(delay(0.05f));
        }

        return playerCam.m_Lens.OrthographicSize;
    }

    private float revertLens()
    {

        if (playerCam.m_Lens.OrthographicSize > 5f)
        {

            playerCam.m_Lens.OrthographicSize -= 0.005f;
            StartCoroutine(delay(0.05f));
        }

        return playerCam.m_Lens.OrthographicSize;
    }

    private IEnumerator delay(float seconds)
    {

        yield return new WaitForSeconds(seconds);
    }
}
