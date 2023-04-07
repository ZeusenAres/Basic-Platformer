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
    private float defaultOrthographicSize;

    void Awake()
    {

        playerMovement = player.GetComponent<PlayerMovement>();
        defaultSpeed = playerMovement.getSpeed();
        defaultJumpForce = playerMovement.getJumpForce();
        defaultOrthographicSize = playerCam.m_Lens.OrthographicSize;
    }

    void Update()
    {

        if(playerMovement.getSpeed() > defaultSpeed || playerMovement.getJumpForce() > defaultJumpForce)
        {

            if(playerCam.m_Lens.OrthographicSize < 7f)
            {

                playerCam.m_Lens.OrthographicSize += 0.05f;
                StartCoroutine(delay(0.05f));
            }
        }
        
        if(playerMovement.getSpeed() == defaultSpeed || playerMovement.getJumpForce() == defaultJumpForce)
        {

            if (playerCam.m_Lens.OrthographicSize > defaultOrthographicSize)
            {

                playerCam.m_Lens.OrthographicSize -= 0.005f;
                StartCoroutine(delay(0.05f));
            }
        }
        //Debug.Log(defaultSpeed);
    }

    private IEnumerator delay(float seconds)
    {

        yield return new WaitForSeconds(seconds);
    }
}
