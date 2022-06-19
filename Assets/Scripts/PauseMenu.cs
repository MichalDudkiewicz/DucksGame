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
        MenuSoundManager.Instance.PlayBtn();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Unpause()
    {
        MenuSoundManager.Instance.PlayBtn();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Restart()
    {
        MenuSoundManager.Instance.PlayBtn();
        SceneManager.LoadScene("SampleScene");
        Unpause();
    }

    public void Exit()
    {
        MenuSoundManager.Instance.PlayBtn();
        SceneManager.LoadScene("Main Menu");
        Unpause();
        MenuSoundManager.Instance.MenuMusic();
    }

    public void PlayBtn()
    {
        MenuSoundManager.Instance.PlayBtn();
    }
}
