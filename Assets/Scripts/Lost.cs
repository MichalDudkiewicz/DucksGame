using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lost : MonoBehaviour
{
    public bool isEnabled = false;

    // Update is called once per frame
    void Update()
    {
        if (isEnabled && Input.touchCount > 0)
        {
            SceneManager.LoadScene("Main Menu");
            Time.timeScale = 1f;
        }
    }
}
