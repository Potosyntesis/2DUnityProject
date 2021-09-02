using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D enemyRB;
    public float moveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.velocity = new Vector2(moveSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        transform.localScale = new Vector2(Mathf.Sign(moveSpeed) * 5, 5);
        moveSpeed = moveSpeed * -1;
    }

}
