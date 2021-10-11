using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    float direction = 1;
    public float jumpSpeed;

    public float fallMultiplier;
    public float lowJumpMultiplier;

    

    Rigidbody2D rb;
    Animator anim;

    bool isJump;

    bool isGrounded;
    public LayerMask layerGround;
    public BoxCollider2D feetPos;

    public bool FastGame;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        InputManager();
        Animations();
    }

    private void FixedUpdate()
    {
        Movement();
        CheckGround();
        Jump();
    }

    void InputManager()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJump = true;
        }
    }


    void Movement()
    {
        rb.velocity = new Vector2(direction * moveSpeed * Time.deltaTime, rb.velocity.y);
    }

    void Jump()
    {
        if (isJump)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed * Time.deltaTime), ForceMode2D.Impulse);
            isJump = false;
        }

        //fourlines better jump
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.IsTouchingLayers(feetPos, layerGround);
    }

    void Animations()
    {
        anim.SetFloat("VelX", rb.velocity.x);
        anim.SetBool("Grounded", isGrounded);
        anim.SetBool("Fast", FastGame);

        if (!FastGame)
        {
            if (rb.velocity.y > 0 && !isGrounded)
            {
                anim.SetBool("Jump", true);
                anim.SetBool("FallingSlow", false);
            }
            else if (rb.velocity.y < 0 && !isGrounded)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("FallingSlow", true);
            }
            else if (isGrounded)
            {
                anim.SetBool("Jump", false);
                anim.SetBool("FallingSlow", false);
            }
        }
    }
}
