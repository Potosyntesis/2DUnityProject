using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    BoxCollider2D jumpCollide;
    Rigidbody2D playerRB;
    public float moveSpeed;
    Animator playerAni;
    CapsuleCollider2D playerCollider;
    public float climbSpeed = 2.0f;
    public int coinsColllected;
    bool isAlive = true;

    void Start()
    {
        playerAni = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
        jumpCollide = GetComponent<BoxCollider2D>();
        playerCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (isAlive)
        {
        Move();
        Jump();
        Climb();
        dead();

        }

    }

    private void Move()
    {
        float movement = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(movement * moveSpeed, playerRB.velocity.y);
        playerRB.velocity = playerVelocity;

        bool playerHorizontalMovement = Mathf.Abs(playerRB.velocity.x) > 0;

        if (playerHorizontalMovement)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRB.velocity.x), 1);
        }

        playerAni.SetBool("isWalk", playerHorizontalMovement);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCollide.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                playerAni.SetBool("isJump", true);
                playerRB.velocity += new Vector2(0, 6);
            }
        }
        else
        {
            playerAni.SetBool("isJump", false);
        }
    }

    private void Climb()
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Interact")) && Input.GetKey(KeyCode.W))
        {
            playerAni.SetBool("isClimb", true);
            Vector2 climbVelocity = new Vector2(playerRB.velocity.x, climbSpeed);
            playerRB.velocity = climbVelocity;
        }
        else
        {
            playerAni.SetBool("isClimb", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    void dead()
    {
        if (playerCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            playerRB.velocity = new Vector2(0, 10);
            playerAni.SetTrigger("Dead");
            isAlive = false;
        }
    }
}


