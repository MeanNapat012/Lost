using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

}
