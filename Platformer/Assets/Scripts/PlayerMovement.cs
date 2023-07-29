using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject self;
    [SerializeField] GameObject mainHandler;
    private PlayerDeserializer playerInfo;
    private List<Default> properties;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sprite;
    //private const float defaultSpeed = 10f, defaultJumpForce = 20f, defaultDashTime = 0.1f, defaultDashCooldown = 0.15f, defaultDashForce = 24f;
    private float speed, jumpForce, dashForce, dashTime, dashCooldown;
    private bool isGroundedLeft, isGroundedRight, isDashing = false, canDash = true;
    [SerializeField] List<GameObject> groundChecks = new List<GameObject>();

    void Start()
    {

        playerInfo = mainHandler.GetComponent<PlayerDeserializer>();
        rb2d = self.GetComponent<Rigidbody2D>();
        anim = self.GetComponent<Animator>();
        sprite = self.GetComponent<SpriteRenderer>();
        properties = playerInfo.getDefaults();

        foreach (var defaults in properties)
        {

            speed = defaults.speed;
            jumpForce = defaults.jumpForce;
            dashForce = defaults.dashForce;
            dashTime = defaults.dashTime;
            dashCooldown = defaults.dashCooldown;
        }
        //Position position = savedData.getSavedPositions();
        //self.transform.SetPositionAndRotation(new Vector3(position.x, position.y, 0f), Quaternion.identity);
    }
    void FixedUpdate()
    {

        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        if(isDashing == false)
        {

            rb2d.velocity = new Vector2(horizontalMovement * speed, rb2d.velocity.y);
        }

        /*if (rb2d.velocity.y < 0)
        {
            Debug.Log("falling");
        }
        if (rb2d.velocity.y > 0)
        {
            Debug.Log("rising");
        }*/

        if(horizontalMovement != 0 && isGroundedLeft == true || isGroundedRight == true)
        {

            anim.SetBool("isRunning", true);
        }

        if (horizontalMovement == 0)
        {

            anim.SetBool("isRunning", false);
        }

        int count = 0;

        foreach (var groundCheck in groundChecks)
        {

            if(count == 0)
            {

                isGroundedLeft = groundCheck.GetComponent<PlayerGroundedHandler>().getGroundedStatus();
            }

            if (count == 1)
            {

                isGroundedRight = groundCheck.GetComponent<PlayerGroundedHandler>().getGroundedStatus();
            }

            if (count >= 1)
            {

                count = 0;
                break;
            }

            count++;
        }

        if (isGroundedLeft == true || isGroundedRight == true)
        {

            foreach (var defaultValue in properties)
            {

                dashCooldown = defaultValue.dashCooldown;
            }
            jump();
        }

        if(isGroundedLeft == false || isGroundedRight == false && canDash == false)
        {

            dashCooldown = 0.5f;
        }

        if(Input.GetKey(KeyCode.LeftShift) == true || Input.GetKey(KeyCode.JoystickButton7) == true)
        {

            if (canDash == false)
            {

                return;
            }
            StartCoroutine(dash(sprite.flipX));
        }

        if (horizontalMovement > 0)
        {

            sprite.flipX = true;
        }

        if (horizontalMovement < 0)
        {

            sprite.flipX = false;
        }

        //Debug.Log(speed);
        //Debug.Log(jumpForce);
    }

    private void jump()
    {

        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton1))
        {

            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    private IEnumerator dash(bool flipX)
    {

        isDashing = true;
        if (canDash == true)
        {

            canDash = false;
            rb2d.velocity = flipX == true ? new Vector2(dashForce, rb2d.velocity.y) : new Vector2(-dashForce, rb2d.velocity.y);
        }
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        Debug.Log("Can Dash");
        canDash = true;
    }

    public float setSpeed(float speed)
    {

        return this.speed = speed;
    }

    public float getSpeed()
    {

        return speed;
    }

    public float setJumpForce(float jumpForce)
    {

        return this.jumpForce = jumpForce;
    }

    public float getJumpForce()
    {

        return jumpForce;
    }
}
