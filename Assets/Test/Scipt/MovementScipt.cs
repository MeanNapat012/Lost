using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementScipt : MonoBehaviour
{
    public Animator animator;
    public Joystick joystick;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Transform sword;

    private bool isFacingRight = true;

    void Start()
    {
        // Make the sword a child of the character's transform
        sword.parent = transform;

        // Add Rigidbody2D to Player object
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get direction from joystick
        Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;

        // Move the game object if joystick is moved
        if (direction.magnitude > 0)
        {
            rb.velocity = direction * moveSpeed;
            //animator.SetFloat("speed", moveSpeed);

            // Flip the character if moving to the right
            if (direction.x > 0 && !isFacingRight)
            {
                FlipCharacter();
            }
            // Flip the character back if moving to the left
            else if (direction.x < 0 && isFacingRight)
            {
                FlipCharacter();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            //animator.SetFloat("speed", 0f);
        }

        if (rb.constraints == RigidbodyConstraints2D.None)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void AttackButton()
    {
        animator.SetTrigger("attack");
    }

    // OnTriggerEnter2D is called when the Collider2D other enters the trigger (Player Collider)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            rb.velocity = Vector2.zero;
        }
    }


}
