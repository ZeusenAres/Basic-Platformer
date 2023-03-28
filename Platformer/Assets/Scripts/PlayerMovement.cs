using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject self;
    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sprite;
    private const float defaultSpeed = 10f, defaultJumpForce = 6f;
    private float speed = defaultSpeed, jumpForce = defaultJumpForce;
    private bool isGrounded;

    void Awake()
    {
        rb2d = self.GetComponent<Rigidbody2D>();
        anim = self.GetComponent<Animator>();
        sprite = self.GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(horizontalMovement * speed, rb2d.velocity.y);

        if(isGrounded == true)
        {

            if(Input.GetKey(KeyCode.Space))
            {

                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Platform"))
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
