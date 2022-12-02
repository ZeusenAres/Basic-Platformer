using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] Animator anim;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    private bool isGrounded;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float horizontalMovement = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2 (horizontalMovement * speed, rb2d.velocity.y);

        if(isGrounded == true)
        {

            if(Input.GetKey(KeyCode.Space))
            {

                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }
        }

        if(horizontalMovement > 0)
        {

            sprite.flipX = true;
        }

        if (horizontalMovement < 0)
        {

            sprite.flipX = false;
        }
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
