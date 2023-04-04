using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHp : MonoBehaviour
{
    public int MaxHealt = 100;
    public int CurrentHealth;
    public HealthBar healthBar;
    public GameOver gameover;

    
    void Start()
    {
        CurrentHealth = MaxHealt;
        healthBar.SetMaxHealth(MaxHealt);
    }

   
    void Update()
    {
        if(CurrentHealth <= 0)
        {
            gameover.GameOverActive();
        }
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        healthBar.SetHealth(CurrentHealth);

    }

    public void OnTriggerEnter2D(Collider2D Heal)
    {
        if(Heal.tag == "Health")
        {
            if(CurrentHealth != MaxHealt)
            {
                Destroy(Heal.gameObject);
                CurrentHealth += 20;
                healthBar.SetHealth(CurrentHealth);
            }
        }
    }

    public void Check(bool dead)
    {
        if(dead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    
}
