using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tele : MonoBehaviour
{
    public Transform room;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.transform.position = room.position;
        }
    } }
    

