using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Unpause()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Unpause();
    }

    public void Exit()
    {
        SceneManager.LoadScene("Main Menu");
        Unpause();
        MenuSoundManager.Instance.MenuMusic();
    }
}
