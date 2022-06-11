using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Won : MonoBehaviour
{
    public bool isEnabled = false;
    // Start is called before the first frame update

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
