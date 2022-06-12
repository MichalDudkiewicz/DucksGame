using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Won : MonoBehaviour
{
    public Text level;
    public Text score;

    public void Continue()
    {
        PlayerPrefs.SetInt("currentLevel", GameManager.Instance.currentLevel + 1);
        GameManager.Instance.ShowUI();
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void TryAgain()
    {
        GameManager.Instance.ShowUI();
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }
}
