using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPosionInFirstRoom : MonoBehaviour
{
   public List<GameObject> HealthPotion;
   public int minHealth = 1;
   public int maxHealth = 5;
   public GameObject area;
   public int CountHealth;

   void start()
   {
        CountHealth = 0;
   }

   private GameObject SelectRandomHealthPrefab()
   {
        int randomIndex = Random.Range(0, HealthPotion.Count);
        return HealthPotion[randomIndex];
   }

   private void OnTriggerEnter2D(Collider2D col)
   {
    if(CountHealth <= 0)
    {
        if(col.tag == "Player")
        {
            int healthCount = Random.Range(minHealth, maxHealth + 1);
            for(int i = 0; i < healthCount; i++)
            {
                GameObject selectedPrefab = SelectRandomHealthPrefab();
                Vector2 spawnPosition = new Vector2(
                    Random.Range(area.transform.position.x - area.transform.localScale.x / 2, area.transform.position.x + area.transform.localScale.x / 2),
                    Random.Range(area.transform.position.y - area.transform.localScale.y / 2, area.transform.position.y + area.transform.localScale.y / 2)
                );
                Instantiate(selectedPrefab, spawnPosition, Quaternion.identity, transform);
            }
        }
        CountHealth++;
    }
   } 
}
