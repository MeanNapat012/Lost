using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> roomPrefabs;
    public GameObject roomSpawnPlayerPrefab;
    public GameObject roomEndPrefab;
    public int numberOfRooms = 10;

    private List<GameObject> rooms = new List<GameObject>();

    private void Start()
    {
        // Spawn the spawn room
        GameObject roomSpawnPlayer = Instantiate(roomSpawnPlayerPrefab, transform.position, Quaternion.identity);
        rooms.Add(roomSpawnPlayer);

        // Spawn the end room
        GameObject roomEnd = Instantiate(roomEndPrefab, transform.position, Quaternion.identity);
        rooms.Add(roomEnd);

        // Spawn the remaining rooms
        for (int i = 0; i < numberOfRooms - 2; i++)
        {
            int randomIndex = Random.Range(0, roomPrefabs.Count);
            GameObject room = Instantiate(roomPrefabs[randomIndex], transform.position, Quaternion.identity);
            rooms.Add(room);
        }

        // Position the rooms randomly
        for (int i = 0; i < rooms.Count; i++)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(-10f, 10f);
            rooms[i].transform.position = new Vector3(x, y, 0f);
        }
    }
}
