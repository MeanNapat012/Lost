using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackScipt : MonoBehaviour
{
    
    public int damage = 20;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

}
