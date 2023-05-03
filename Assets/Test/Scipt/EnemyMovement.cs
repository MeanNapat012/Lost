using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Transform player;
    private bool facingRight = false;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (player == null) return;

        // Check if player is on the opposite side of the enemy
        if ((player.position.x < transform.position.x && facingRight) || (player.position.x > transform.position.x && !facingRight))
        {
            // Flip the enemy
            Flip();
        }
    }
    private void Flip()
    {
    // Switch the value of facingRight
        facingRight = !facingRight;

    // Flip the enemy's scale along the x-axis
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


    void FixedUpdate()
    {
        if(player != null)
        {
             Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
        }

    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the player or another object
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstacle"))
        {
            // Lock the rotation of the enemy when it hits the player or another object
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}