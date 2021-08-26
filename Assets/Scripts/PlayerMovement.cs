using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D playerRB;
    public float moveSpeed;
    Animator playerAni;

    void Start()
    {
        playerAni = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
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
}
