using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSpear : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    
    void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }

    void Update()
    {

    Vector3 dir = player.position - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("attack");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.ResetTrigger("attack");
        }
    }
}