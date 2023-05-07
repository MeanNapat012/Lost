using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Hp;
    public int MaxHp = 100;
    private Room room;
    private bool isInRoom = false;

    void Start()
    {
        Hp = MaxHp;
    }

    void Update()
    {
        if (!isInRoom)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 5f);
            foreach (Collider2D hitCollider in hitColliders)
            {
                Room roomComponent = hitCollider.GetComponent<Room>();
                if (roomComponent != null)
                {
                    room = roomComponent;
                    isInRoom = true;
                    break;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            if (isInRoom && room != null)
            {
                room.EnemyDead();
            }
            Destroy(gameObject);
        }
    }
}
