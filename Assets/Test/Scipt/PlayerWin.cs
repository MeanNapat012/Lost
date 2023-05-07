using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerWin : MonoBehaviour
{
    public int Allroom;
    public int WinRoom = 0;
    public Text MyroomText;
    public int RoomNum;
    public string sceneName;

    void start()
    {
        RoomNum = 0;
        MyroomText.text = "Room : "+ RoomNum;
    }

    public void Numroom(int numroom)
    {
        Allroom = numroom - 2;
    }

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

    public void AllroomInScene(int amount)
    {
        RoomNum = amount;
        MyroomText.text = "Room : "+ RoomNum;
    }
}
