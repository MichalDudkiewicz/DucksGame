using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lost : MonoBehaviour
{
    public Text level;
    public Text score;

    public void Continue()
    {
        GameManager.Instance.ShowUI();
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void ExitLevel()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
}
