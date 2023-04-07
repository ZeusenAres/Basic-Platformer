using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedHandler : MonoBehaviour
{

    private bool isGrounded;

    public bool getGroundedStatus()
    {

        return isGrounded;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {

            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {

            isGrounded = false;
        }
    }
}
