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
        sword.parent = transform;
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;


        if (direction.magnitude > 0)
        {
            rb.velocity = direction * moveSpeed;
            if (direction.x > 0 && !isFacingRight)
            {
                FlipCharacter();
            }
            else if (direction.x < 0 && isFacingRight)
            {
                FlipCharacter();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            rb.velocity = Vector2.zero;
        }
    }


}
