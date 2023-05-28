using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    public int Allroom;
    public int WinRoom = 0;
    public int RoomNum;
    public string sceneName;


    public void CountRoomWin()
    {
        WinRoom++;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(Allroom == WinRoom)
        {
            if(col.tag == "FinalSpawn")
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }

}
