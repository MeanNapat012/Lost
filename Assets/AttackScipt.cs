using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScipt : MonoBehaviour
{
    
    public int enemy = 0;
    public int damage = 20;
    public GameOver gameover;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyHealth>().Takedanage(damage);
            enemy++;
        }
    }

    void Update()
    {
        if(enemy == 25)
        {
            gameover.GameOverActive();
        }
    }
}
