using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwordDirection : MonoBehaviour
{
    public Animator animator;
    public List<BoxCollider2D> attackBoxes;
    public PlayerHp playerHp;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("attack");

            foreach (var attackBox in attackBoxes)
            {
                playerHp.TakeDamage(10);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.ResetTrigger("attack");

            foreach (var attackBox in attackBoxes)
            {
                attackBox.isTrigger = false;
            }
        }
    }
}