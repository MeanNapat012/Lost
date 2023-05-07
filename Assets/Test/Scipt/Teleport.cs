using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float minDistance = 10f;
    public float cooldown = 30f;

    private bool onCooldown = false;
    private float lastUsedTime = 0f;
    private float cooldownTime = 0f;

    private void Start()
    {
        cooldownTime = lastUsedTime + cooldown;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !onCooldown)
        {
            StartCoroutine(TeleportPlayer(other.gameObject));
            onCooldown = true;
            lastUsedTime = Time.time;
            cooldownTime = lastUsedTime + cooldown;
        }
    }

    IEnumerator TeleportPlayer(GameObject player)
    {
        List<GameObject> spawnPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Room"));
        spawnPoints.Remove(gameObject); // Remove current spawn point from the list
        if (spawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Count);
            GameObject randomSpawn = spawnPoints[randomIndex];
            while (Vector2.Distance(randomSpawn.transform.position, transform.position) < minDistance)
            {
                randomIndex = Random.Range(0, spawnPoints.Count);
                randomSpawn = spawnPoints[randomIndex];
            }
            player.transform.position = randomSpawn.transform.position;
        }
        else
        {
            Debug.LogError("No valid spawn points found.");
        }

        yield return new WaitForSeconds(0.1f);

        onCooldown = false;
    }

    private void Update()
    {
        if (Time.time >= cooldownTime)
        {
            onCooldown = false;
        }
    }
}
