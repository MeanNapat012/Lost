using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3 : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public GameObject Coin;
    public int minCoin = 1;
    public int maxCoin = 5;
    public int numberOfPrefabs;
    public int numEnemies;
    public GameObject spawnArea;
    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject player;
    private PlayerWin playerWin;
    private bool playerEntered = false;
    private bool TeleportOn = false;
    private int Coinround;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerWin = player.GetComponent<PlayerWin>();

    }

    void Update()
    {
        numEnemies = transform.childCount;
        
        if (numEnemies <= 0 && (TeleportOn == true))
        {
            spawn1.SetActive(true);
            spawn2.SetActive(true);
            spawn3.SetActive(true);
            if(Coinround <= 0)
            {
                RandomCoin();
            }
        }
        else if ((playerEntered == true) && numEnemies == 0)
        {
            StartCoroutine(SpawnEnemies());
            playerEntered = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerEntered = true;
            playerWin.CountRoomWin();
            gameObject.GetComponent<Collider2D>().enabled = false;
            spawn1.SetActive(false);
            spawn2.SetActive(false);
            spawn3.SetActive(false);
        }
    }

    private GameObject SelectRandomPrefab()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Count);
        return enemyPrefabs[randomIndex];
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < numberOfPrefabs; i++)
        {
            GameObject selectedPrefab = SelectRandomPrefab();
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnArea.transform.position.x - spawnArea.transform.localScale.x / 2, spawnArea.transform.position.x + spawnArea.transform.localScale.x / 2),
                Random.Range(spawnArea.transform.position.y - spawnArea.transform.localScale.y / 2, spawnArea.transform.position.y + spawnArea.transform.localScale.y / 2)
            );
            Instantiate(selectedPrefab, spawnPosition, Quaternion.identity, transform);
        }
        TeleportOn = true;
    }

    public void EnemyDead()
    {
        numEnemies--;
    }
    
    public void RandomCoin()
    {
        int CoinCount = Random.Range(minCoin, maxCoin + 1);
            for(int i = 0; i < CoinCount; i++)
            {
                GameObject selectedPrefab = Coin;
                Vector2 spawnPosition = new Vector2(
                    Random.Range(spawnArea.transform.position.x - spawnArea.transform.localScale.x / 2, spawnArea.transform.position.x + spawnArea.transform.localScale.x / 2),
                    Random.Range(spawnArea.transform.position.y - spawnArea.transform.localScale.y / 2, spawnArea.transform.position.y + spawnArea.transform.localScale.y / 2)
                );
                Instantiate(selectedPrefab, spawnPosition, Quaternion.identity, transform);
                
            }
            Coinround++;
    }
}
