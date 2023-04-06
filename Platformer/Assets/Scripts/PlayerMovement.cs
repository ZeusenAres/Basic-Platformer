using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject self;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sprite;
    private const float defaultSpeed = 10f, defaultJumpForce = 20f, defaultDashTime = 0.1f, defaultDashCooldown = 0.15f, defaultDashForce = 24f;
    private float speed = defaultSpeed, jumpForce = defaultJumpForce, dashForce = defaultDashForce, dashTime = defaultDashTime, dashCooldown;
    private bool isGrounded, isDashing = false, canDash = true;
    [SerializeField] List<GameObject> groundChecks = new List<GameObject>();

    void Awake()
    {

        rb2d = self.GetComponent<Rigidbody2D>();
        anim = self.GetComponent<Animator>();
        sprite = self.GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");

        if(isDashing == false)
        {

            rb2d.velocity = new Vector2(horizontalMovement * speed, rb2d.velocity.y);
        }

        foreach (var groundCheck in groundChecks)
        {
            
            isGrounded = groundCheck.GetComponent<PlayerGroundedHandler>().getGroundedStatus();
        }

        if (isGrounded == true)
        {

            dashCooldown = defaultDashCooldown;
            jump();
        }

        if(isGrounded == false && canDash == false)
        {

            dashCooldown = 1.5f;
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
