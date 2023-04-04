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
    public float swordRadius = 1.0f;

    private bool isFacingRight = true;

    void Update()
    {
        // Get direction from joystick
        Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;

        // Move the game object if joystick is moved
        if (direction.magnitude > 0)
        {
            transform.Translate(direction * moveSpeed * Time.deltaTime);

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

            // Rotate the sword based on joystick direction
            float joystickAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            sword.rotation = Quaternion.Euler(0f, 0f, joystickAngle);
            // Position the sword in front of the character based on the radius
            Vector2 swordPosition = direction * swordRadius;
            sword.position = transform.position + new Vector3(swordPosition.x, swordPosition.y, 0f);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstacle"))
        {   
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}