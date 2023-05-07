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
    public string sceneName;

    void Start()
    {
        
        CurrentHealth = MaxHealt;
        healthBar.SetMaxHealth(MaxHealt);
    }

   
    void Update()
    {
        if(CurrentHealth <= 0)
        {
            SceneManager.LoadScene(sceneName);
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
        if(Heal.tag == "BigHealth")
        {
            if(CurrentHealth <= 400)
            {
                Destroy(Heal.gameObject);
                CurrentHealth += 100;
                healthBar.SetHealth(CurrentHealth);
            }
        }
    }



}
