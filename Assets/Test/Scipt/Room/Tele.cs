using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tele : MonoBehaviour
{
    public List<BoxCollider2D> SpawnTeleport;

    private void Start()
    {
        // คำนวณระยะห่างระหว่างข้อมูลทั้งหมดใน SpawnTeleport List
        for (int i = 0; i < SpawnTeleport.Count - 1; i++)
        {
            for (int j = i + 1; j < SpawnTeleport.Count; j++)
            {
                float distance = Vector2.Distance(SpawnTeleport[i].transform.position, SpawnTeleport[j].transform.position);
                Debug.Log("Distance between " + SpawnTeleport[i].name + " and " + SpawnTeleport[j].name + ": " + distance);
            }
        }
    }
}