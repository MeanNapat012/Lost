using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanal;

    public void Pause()
    {
        PausePanal.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reseume()
    {
        PausePanal.SetActive(false);
        Time.timeScale = 1;
    }

}
