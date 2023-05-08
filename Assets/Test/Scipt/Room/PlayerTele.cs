using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTele : MonoBehaviour
{
    private float minDistance = 10f;
    private float maxDistance = 50f;
    private bool teleport = true;
    private float cooldownTime = 10f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Spawn") && !col.gameObject.Equals(gameObject) && teleport)
        {
            GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");
            GameObject targetSpawnPoint = null;
            float closestDistance = Mathf.Infinity;

            foreach (GameObject spawnPoint in spawnPoints)
            {
                if (!spawnPoint.Equals(gameObject))
                {
                    float distance = Vector2.Distance(transform.position, spawnPoint.transform.position);

                    if (distance >= minDistance && distance <= maxDistance && distance < closestDistance)
                    {
                        closestDistance = distance;
                        targetSpawnPoint = spawnPoint;
                    }
                }
            }

            if (targetSpawnPoint != null)
            {
                Vector2 direction = transform.right;
                Vector2 position = (Vector2)transform.position + (direction * closestDistance);

                transform.position = position;
                StartCoroutine(CooldownTeleport());
            }
            else
            {
                Debug.Log("No valid spawn point found within range.");
            }
        }
    }

    private IEnumerator CooldownTeleport()
    {
        yield return new WaitForSeconds(cooldownTime);
        teleport = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Spawn") && col.gameObject.Equals(gameObject))
        {
            teleport = true;
        }
    }
}
