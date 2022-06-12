using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Won : MonoBehaviour
{
    public Text level;

    public bool isEnabled = false;

    // Update is called once per frame
    void Update()
    {
        if (isEnabled && Input.touchCount > 0)
        {
            PlayerPrefs.SetInt("level" + (GameManager.Instance.currentLevel+1).ToString(), 1);
            SceneManager.LoadScene("Main Menu");
            Time.timeScale = 1f;
        }
    }
}
